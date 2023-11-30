using System.Security.Claims;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Models.Diary;
using CalorieTracker.Server.Models.Food;
using CalorieTracker.Server.Models.FoodDiary;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.EndpointHandlers;

public static class DiaryHandlers
{
    public static async Task<Results<Ok<DiaryDto>, NotFound>> GetFoodDiaryByDateAsync(
        ApplicationDbContext applicationDbContext,
        DateTime date,
        ClaimsPrincipal claimsPrincipal)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var diary = await applicationDbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.Foods)
            .FirstOrDefaultAsync(d => d.UserId == userId
                                      && d.Date.Date == date.Date);

        if (diary == null)
        {
            return TypedResults.NotFound();
        }

        var foodDiaries = diary.FoodDiaries.Select(fd => new FoodDiaryDto
        {
            FoodDiaryId = fd.FoodDiaryId,
            DiaryId = fd.DiaryId,
            MealTypeId = fd.MealTypeId,
            Foods = fd.Foods.Select(f => new FoodDto
            {
                FoodId = f.FoodId,
                Name = f.Name,
                Calories = f.Calories,
                Protein = f.Protein,
                Fat = f.Fat,
                Carbs = f.Carbs
            }).ToList()
        }).ToList();

        return TypedResults.Ok<DiaryDto>(new DiaryDto
        {
            DiaryId = diary.DiaryId,
            UserId = diary.UserId,
            Date = diary.Date,
            FoodDiaries = foodDiaries
        });
    }
}