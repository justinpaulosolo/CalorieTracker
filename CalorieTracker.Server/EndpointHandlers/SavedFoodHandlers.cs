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
    
    public static async Task<Results<Ok<SavedFoodDto>, BadRequest>> GetSavedFoodAsync(
        ISavedFoodService savedFoodService,
        int savedFoodId,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var savedFood = await savedFoodService.GetSavedFoodByIdAsync(savedFoodId, userId!);
            
            if (savedFood == null)
            {
                return TypedResults.BadRequest();
            }
            
            return TypedResults.Ok(new SavedFoodDto
            {
                SavedFoodId = savedFood.SavedFoodId,
                Name = savedFood.Name,
                Calories = savedFood.Calories,
                Protein = savedFood.Protein,
                Carbs = savedFood.Carbs,
                Fat = savedFood.Fat
            });
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.Ok(new SavedFoodDto());
        }
    }
    
    public static async Task<Ok<bool>> DeleteSavedFoodAsync(
        ISavedFoodService savedFoodService,
        int savedFoodId,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var success = await savedFoodService.DeleteSavedFoodAsync(savedFoodId, userId!);
            return TypedResults.Ok(success);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.Ok(false);
        }
    }
}