using System.Security.Claims;
using CalorieTracker.Server.Models.NutritionGoal;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Server.EndpointHandlers;

public static class NutritionGoalHandler
{
    public static async Task<Results<Ok<int>, BadRequest<string>>> CreateNutritionGoalAsync(
        INutritionGoalService nutritionGoalService,
        CreateNutritionGoalDto createNutritionGoalDto,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var nutritionGoalId = await nutritionGoalService.CreateNutritionGoalAsync(createNutritionGoalDto, userId!);
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
        INutritionGoalService nutritionGoalService,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var nutritionGoal = await nutritionGoalService.GetNutritionGoalAsync(userId!);
            return TypedResults.Ok(nutritionGoal);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.BadRequest(ex.Message);
        }
    }
    
    // TODO: Add validation to ensure the user is updating their own nutrition goal
    // TODO: HTTP status code
    public static async Task<Results<Ok<NutritionGoalDto>, BadRequest<string>>> UpdateNutritionGoalAsync(
        [FromServices]INutritionGoalService nutritionGoalService,
        [FromBody]UpdateNutritionGoalDto updateNutritionGoalDto,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var nutritionGoal = await nutritionGoalService.UpdateNutritionGoalAsync(updateNutritionGoalDto, userId!);
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