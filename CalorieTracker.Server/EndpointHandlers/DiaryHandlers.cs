using System.Security.Claims;
using CalorieTracker.Server.Models.Diary;
using CalorieTracker.Server.Models.Food;
using CalorieTracker.Server.Models.FoodDiary;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieTracker.Server.EndpointHandlers;

public static class DiaryHandlers
{
    public static async Task<Results<Ok<DiaryDto>, NotFound<string>>> GetFoodDiaryByDateAsync(
        IDiaryService diaryService,
        IFoodDiaryService foodDiaryService,
        DateTime date,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var diary = await foodDiaryService.GetFoodDiaryByDateAsync(date, userId!);
            if (diary == null)
            {
                return TypedResults.NotFound("Not found");
            }
            return TypedResults.Ok(new DiaryDto
            {
                DiaryId = diary.DiaryId,
                UserId = diary.UserId,
                Date = diary.Date,
                FoodDiaries = diary.FoodDiaries.Select(fd => new FoodDiaryDto
                {
                    FoodDiaryId = fd.FoodDiaryId,
                    DiaryId = fd.DiaryId,
                    MealTypeId = fd.MealTypeId,
                    Foods = fd.FoodDiaryEntries.Select(f => new FoodDto
                    {
                        FoodId = f.FoodId,
                        FoodDiaryEntryId = f.FoodDiaryEntryId,
                        Name = f.Food.Name,
                        Calories = f.Food.Calories,
                        Protein = f.Food.Protein,
                        Fat = f.Food.Fat,
                        Carbs = f.Food.Carbs
                    }).ToList()
                }).ToList()
            });
        }
        catch (Exception ex)
        {
            return TypedResults.NotFound(ex.Message);
        }
    }
}
