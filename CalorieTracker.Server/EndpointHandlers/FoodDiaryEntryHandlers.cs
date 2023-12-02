using System.Security.Claims;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.FoodDiaryEntry;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.EndpointHandlers;

public static class FoodDiaryEntryHandlers
{
    public static async Task<Results<Ok<int>, BadRequest<string>>> CreateFoodDiaryEntryAsync(
        IFoodDiaryEntryService foodDiaryEntryService,
        CreateFoodDiaryEntryDto createFoodDiaryEntryDto,
        DateTime date,
        string meal,
        ClaimsPrincipal claimsPrincipal
        )
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var foodDiaryEntryId = await foodDiaryEntryService.CreateFoodDiaryEntryAsync(createFoodDiaryEntryDto,
                date,
                meal,
                userId!);
            
            return TypedResults.Ok(foodDiaryEntryId);
        }
        catch (Exception ex)
        {
            // TODO: implement logger
            //logger.LogError(ex, "Error creating food diary entry");
            return TypedResults.BadRequest(ex.Message);
        }
    }

    public static async Task<Results<NoContent, NotFound>> DeleteFoodDiaryEntryAsyncV2(
        IFoodDiaryEntryService foodDiaryEntryService,
        int foodDiaryEntryId,
        ClaimsPrincipal claimsPrincipal)
    {
        try
        {
            var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
            var isDeleted = await foodDiaryEntryService.DeleteFoodDiaryEntryByIdAsync(foodDiaryEntryId, userId!);
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

    public static async Task<Results<NoContent, NotFound>> DeleteFoodDiaryEntryAsync(
        ApplicationDbContext applicationDbContext,
        int foodDiaryEntryId,
        ClaimsPrincipal claimsPrincipal)
    {
        var foodDiaryEntry = await GetFoodDiaryEntry(applicationDbContext, foodDiaryEntryId);

        if (foodDiaryEntry == null)
        {
            return TypedResults.NotFound();
        }

        await RemoveFoodDiaryEntry(applicationDbContext, foodDiaryEntry);

        if (!await IsFoodUsedElsewhere(applicationDbContext, foodDiaryEntry.Food))
        {
            await RemoveFood(applicationDbContext, foodDiaryEntry.Food);
        }

        return TypedResults.NoContent();
    }

    private static async Task<FoodDiaryEntry?> GetFoodDiaryEntry(ApplicationDbContext applicationDbContext, int foodDiaryEntryId)
    {
        return await applicationDbContext.FoodDiaryEntries
            .Include(fde => fde.Food)
            .FirstOrDefaultAsync(fde => fde.FoodDiaryEntryId == foodDiaryEntryId);
    }

    private static async Task RemoveFoodDiaryEntry(ApplicationDbContext applicationDbContext, FoodDiaryEntry foodDiaryEntry)
    {
        applicationDbContext.FoodDiaryEntries.Remove(foodDiaryEntry);
        await applicationDbContext.SaveChangesAsync();
    }

    private static async Task<bool> IsFoodUsedElsewhere(ApplicationDbContext applicationDbContext, Food food)
    {
        return await applicationDbContext.FoodDiaryEntries.AnyAsync(fde => fde.FoodId == food.FoodId)
               || await applicationDbContext.SavedFoodItems.AnyAsync(uf => uf.FoodId == food.FoodId);
    }

    private static async Task RemoveFood(ApplicationDbContext applicationDbContext, Food food)
    {
        applicationDbContext.Foods.Remove(food);
        await applicationDbContext.SaveChangesAsync();
    }
}