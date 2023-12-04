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
