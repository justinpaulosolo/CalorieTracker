using System.Security.Claims;
using CalorieTracker.Server.Models.SavedFood;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieTracker.Server.EndpointHandlers;

public static class SavedFoodHandlers
{
    public static async Task<Ok<int>> CreateSavedFoodAsync(
        ISavedFoodService savedFoodService,
        CreateSavedFoodDto createSavedFoodDto,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var savedFoodId = await savedFoodService.CreateSavedFoodAsync(createSavedFoodDto, userId!);
            return TypedResults.Ok(savedFoodId);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.Ok(0);
        }
    }
    
    public static async Task<Ok<GetAllSavedFoodsResponse>> GetAllSavedFoodsAsync(
        ISavedFoodService savedFoodService,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var savedFoods = await savedFoodService.GetSavedFoodsAsync(userId!);
            return TypedResults.Ok(new GetAllSavedFoodsResponse { SavedFoods = savedFoods });
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.Ok(new GetAllSavedFoodsResponse());
        }
    }
}