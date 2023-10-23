using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

namespace CalorieTracker.Server.FoodEntries;

public static class FoodEntriesApi
{
    public static RouteGroupBuilder MapFoodEntries(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/FoodEntries");
        group.WithTags("FoodEntries");
        group.MapPost("/", async (ApplicationDbContext context, CreateFoodEntryRequest foodEntryRequest) =>
        {
            if (!MiniValidator.TryValidate(foodEntryRequest, out var errors))
            {
                return Results.ValidationProblem(errors);
            }
            
            // Check if the meal exists
            var meal = await context.Meals.FindAsync(foodEntryRequest.MealId);

            if (meal == null)
            {
                return Results.BadRequest("The meal does not exist.");
            }

            var foodEntry = new FoodEntry()
            {
                MealId = foodEntryRequest.MealId,
                FoodId = foodEntryRequest.FoodId,
                Quantity = foodEntryRequest.Quantity
            };

            context.FoodEntries.Add(foodEntry);
            await context.SaveChangesAsync();

            return Results.Created($"/api/foodEntries/{foodEntry.FoodEntryId}", foodEntryRequest);
        });
        return group;
    }
}