using System.Security.Claims;
using CalorieTracker.Server.Models.NutritionGoal;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieTracker.Server.EndpointHandlers;

public static class NutritionGoalHandler
{
    public static async Task<Results<Ok<int>, BadRequest<string>>> CreateNutritionGoalAsync(
        INutritionGoalServices nutritionGoalServices,
        CreateNutritionGoalDto createNutritionGoalDto,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var nutritionGoalId = await nutritionGoalServices.CreateNutritionGoalAsync(createNutritionGoalDto, userId!);
            return TypedResults.Ok(nutritionGoalId);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.BadRequest(ex.Message);
        }
    }
    
    public static async Task<Results<Ok<NutritionGoalDto>, BadRequest<string>>> GetNutritionGoalAsync(
        INutritionGoalServices nutritionGoalServices,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var nutritionGoal = await nutritionGoalServices.GetNutritionGoalAsync(userId!);
            return TypedResults.Ok(nutritionGoal);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.BadRequest(ex.Message);
        }
    }
    
}