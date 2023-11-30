using System.Security.Claims;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.Food;
using CalorieTracker.Server.Models.FoodDiary;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.EndpointHandlers;

public static class FoodDiaryHandlers
{
    public static async Task<CreatedAtRoute<FoodDiaryDto>> CreateFoodDiaryAsync(
        ApplicationDbContext applicationDbContext,
        CreateFoodDiaryDto createFoodDiaryDto,
        ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var diary = await applicationDbContext.Diaries
            .Include(d => d.FoodDiaries)
            .FirstOrDefaultAsync(d => d.UserId == userId
                                      && d.Date == createFoodDiaryDto.Date);

        if (diary == null)
        {
            diary = new Diary
            {
                UserId = userId!,
                Date = createFoodDiaryDto.Date,
                FoodDiaries = new List<FoodDiary>()
            };
            await applicationDbContext.Diaries.AddAsync(diary);
            await applicationDbContext.SaveChangesAsync();
        }
        
        var foodDiary = await applicationDbContext.FoodDiaries
            .Include(fd =>  fd.Diary)
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.MealTypeId == createFoodDiaryDto.MealTypeId
                                       && fd.Diary.UserId == userId
                                       && fd.Diary.Date.Date == createFoodDiaryDto.Date.Date);

        if (foodDiary == null)
        {
            foodDiary = new FoodDiary
            {
                DiaryId = diary.DiaryId,
                MealTypeId = createFoodDiaryDto.MealTypeId,
            };
            await applicationDbContext.FoodDiaries.AddAsync(foodDiary);
            await applicationDbContext.SaveChangesAsync();
        }
        
        const double epsilon = 0.00001;
        
        var food = await applicationDbContext.Foods
            .FirstOrDefaultAsync(f => f.Name == createFoodDiaryDto.FoodName
                                      && Math.Abs(f.Calories - createFoodDiaryDto.Calories) < epsilon
                                      && Math.Abs(f.Protein - createFoodDiaryDto.Protein) < epsilon
                                      && Math.Abs(f.Fat - createFoodDiaryDto.Fat) < epsilon
                                      && Math.Abs(f.Carbs - createFoodDiaryDto.Carbs) < epsilon);

        if (food == null)
        {
            food = new Food
            {
                Name = createFoodDiaryDto.FoodName,
                Calories = createFoodDiaryDto.Calories,
                Protein = createFoodDiaryDto.Protein,
                Fat = createFoodDiaryDto.Fat,
                Carbs = createFoodDiaryDto.Carbs
            };
            await applicationDbContext.Foods.AddAsync(food);
            await applicationDbContext.SaveChangesAsync();
        }

        var foodDiaryEntry = new FoodDiaryEntry
        {
            FoodDiaryId = foodDiary.FoodDiaryId,
            FoodId = food.FoodId
        };
        await applicationDbContext.FoodDiaryEntries.AddAsync(foodDiaryEntry);
        await applicationDbContext.SaveChangesAsync();

        var foodDiaryDto = new FoodDiaryDto
        {
            FoodDiaryId =  foodDiary.FoodDiaryId,
            DiaryId = foodDiary.DiaryId,
            MealTypeId = foodDiary.MealTypeId,
            Foods = foodDiary.FoodDiaryEntries.Select(fde => new FoodDto
            {
                FoodId = fde.Food.FoodId,
                FoodDiaryEntryId = fde.FoodDiaryEntryId,
                Name = fde.Food.Name,
                Calories = fde.Food.Calories,
                Protein = fde.Food.Protein,
                Fat = fde.Food.Fat,
                Carbs = fde.Food.Carbs
            }).ToList()
        };
        
        return TypedResults.CreatedAtRoute(
            foodDiaryDto,
            "GetFoodDiaryByIdAsync",
            new { foodDiaryId = foodDiary.FoodDiaryId });
    }
    
    public static async Task<Results<Ok<FoodDiaryDto>, NotFound>> GetFoodDiaryByIdAsync(
        ApplicationDbContext applicationDbContext,
        int foodDiaryId,
        ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var foodDiary = await applicationDbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.FoodDiaryId == foodDiaryId && fd.Diary.UserId == userId);

        if (foodDiary == null)
        {
            return TypedResults.NotFound();
        }

        var foodDiaryDto = new FoodDiaryDto
        {
            FoodDiaryId = foodDiary.FoodDiaryId,
            DiaryId = foodDiary.DiaryId,
            MealTypeId = foodDiary.MealTypeId,
            Foods = foodDiary.FoodDiaryEntries.Select(f => new FoodDto
            {
                FoodId = f.FoodId,
                FoodDiaryEntryId = f.FoodDiaryEntryId,
                Name = f.Food.Name,
                Calories = f.Food.Calories,
                Protein = f.Food.Protein,
                Fat = f.Food.Fat,
                Carbs = f.Food.Carbs
            }).ToList()
        };

        return TypedResults.Ok(foodDiaryDto);
    }


}
