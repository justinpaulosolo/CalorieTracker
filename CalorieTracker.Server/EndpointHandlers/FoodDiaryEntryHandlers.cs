using System.Security.Claims;
using CalorieTracker.Server.Models.Food;
using CalorieTracker.Server.Models.FoodDiaryEntry;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CalorieTracker.Server.EndpointHandlers;

public static class FoodDiaryEntryHandlers
{
    public static async Task<Ok<FoodDto>> GetFoodDiaryEntryByIdAsync(
        IFoodDiaryService foodDiaryService,
        int foodDiaryEntryId,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodDiaryEntry = await foodDiaryService.GetFoodDiaryEntryById(foodDiaryEntryId);
            return TypedResults.Ok(foodDiaryEntry);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.Ok(new FoodDto());
        }
    }
    
    public static async Task<Ok<FoodEntriesResponseDto>> GetDiaryFoodsEntriesAsync(
        IFoodDiaryService foodDiaryService,
        DateTime date,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodEntries = await foodDiaryService.GetDiaryFoodsByDate(date, userId!);
            var responseDto = new FoodEntriesResponseDto { Data = foodEntries };
            return TypedResults.Ok(responseDto);
        }
        catch (Exception ex)
        {
            // Log the exception details here
            // Return an appropriate error response
            return TypedResults.Ok(new FoodEntriesResponseDto());
        }
    }
    public static async Task<Results<Ok<int>, BadRequest<string>>> CreateFoodDiaryEntryAsync(
        IFoodDiaryService foodDiaryService,
        CreateFoodDiaryEntryDto createFoodDiaryEntryDto,
        ClaimsPrincipal claimsPrincipal
        )
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodDiaryEntryId = await foodDiaryService.CreateFoodDiaryEntryAsync(createFoodDiaryEntryDto, userId!);
            return TypedResults.Ok(foodDiaryEntryId);
        }
        catch (Exception ex)
        {
            // TODO: implement logger
            //logger.LogError(ex, "Error creating food diary entry");
            return TypedResults.BadRequest(ex.Message);
        }
    }
    
    public static async Task<Results<Ok<int>, NotFound>> UpdateFoodDiaryEntryAsync(
        IFoodDiaryService foodDiaryService,
        UpdateFoodDiaryEntryDto updateFoodDiaryEntryDto,
        int foodDiaryEntryId,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var updatedFoodDiaryEntryId = await foodDiaryService.UpdateFoodDiaryEntryAsync(updateFoodDiaryEntryDto, foodDiaryEntryId, userId!);
            return TypedResults.Ok(updatedFoodDiaryEntryId);
        }
        catch (Exception ex)
        {
            return TypedResults.NotFound();
        }
    }

    public static async Task<Results<NoContent, NotFound>> DeleteFoodDiaryEntryAsync(
        IFoodDiaryService foodDiaryService,
        int foodDiaryEntryId,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var isDeleted = await foodDiaryService.DeleteFoodDiaryEntryByIdAsync(foodDiaryEntryId, userId!);
            if (!isDeleted)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.NoContent();
        }
        catch (Exception ex)
        {
            return TypedResults.NotFound();
        }
    }
}