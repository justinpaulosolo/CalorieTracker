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
            .FirstOrDefaultAsync(fd => fd.MealTypeId == createFoodDiaryDto.MealTypeId
                                       && fd.Diary.UserId == userId
                                       && fd.Diary.Date.Date == createFoodDiaryDto.Date.Date);

        if (foodDiary == null)
        {
            foodDiary = new FoodDiary
            {
                DiaryId = diary.DiaryId,
                MealTypeId = createFoodDiaryDto.MealTypeId,
                Foods = new List<Food>()
            };
            await applicationDbContext.FoodDiaries.AddAsync(foodDiary);
            await applicationDbContext.SaveChangesAsync();
        }

        var food = new Food
        {
            Name = createFoodDiaryDto.FoodName,
            Calories = createFoodDiaryDto.Calories,
            Protein = createFoodDiaryDto.Protein,
            Fat = createFoodDiaryDto.Fat,
            Carbs = createFoodDiaryDto.Carbs
        };

        foodDiary.Foods.Add(food);
        await applicationDbContext.Foods.AddAsync(food);
        await applicationDbContext.SaveChangesAsync();

        var foodDiaryDto = new FoodDiaryDto
        {
            FoodDiaryId = foodDiary.FoodDiaryId,
            DiaryId = foodDiary.DiaryId,
            MealTypeId = foodDiary.MealTypeId,
            Foods = foodDiary.Foods.Select(f => new FoodDto
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Calories = f.Calories,
                Protein = f.Protein,
                Fat = f.Fat,
                Carbs = f.Carbs
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
            .Include(fd => fd.Foods)
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
            Foods = foodDiary.Foods.Select(f => new FoodDto
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Calories = f.Calories,
                Protein = f.Protein,
                Fat = f.Fat,
                Carbs = f.Carbs
            }).ToList()
        };

        return TypedResults.Ok(foodDiaryDto);
    }


}
