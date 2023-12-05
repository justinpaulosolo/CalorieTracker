using System.Security.Claims;
using CalorieTracker.Server.Models;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieTracker.Server.EndpointHandlers;

public static class NutritionHandlers
{
    public static async Task<Results<Ok<NutritionInfo>, NotFound>> GetNutritionInfoAsync(
        IFoodDiaryService foodDiaryService,
        IDiaryService diaryService,
        DateTime date,
        ClaimsPrincipal claimsPrincipal)
    {

        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var diaryId = await diaryService.GetDiaryIdByDateAsync(date, userId!);
            if (diaryId == null)
            {
                return TypedResults.Ok(new NutritionInfo());
            }
            var nutritionInfo = await foodDiaryService.GetNutritionInfoAsync(diaryId.Value);
            
            return TypedResults.Ok(nutritionInfo);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }
}