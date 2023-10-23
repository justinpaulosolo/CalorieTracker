using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.FoodEntries;

public static class FoodEntriesApi
{
    public static RouteGroupBuilder MapFoodEntries(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/FoodEntries");
        group.WithTags("FoodEntries");
        group.MapPost("/", async (ApplicationDbContext context, FoodEntry foodEntry) =>
        {
            // Check if the meal exists
            var meal = await context.Meals.FindAsync(foodEntry.MealId);

            if (meal == null)
            {
                return Results.BadRequest("The meal does not exist.");
            }

            context.FoodEntries.Add(foodEntry);
            await context.SaveChangesAsync();

            return Results.Created($"/api/foodEntries/{foodEntry.FoodEntryId}", foodEntry);
        });
        return group;
    }
}