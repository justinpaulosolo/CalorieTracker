using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MealEntries.Delete;

public static class Endpoint
{
    public static WebApplication DeleteMealEntry(this WebApplication app)
    {
        app.MapDelete("api/meal-entries/{id}", HandleAsync).RequireAuthorization();
        return app;
    }

    private static async Task<IResult> HandleAsync(int id, ApplicationDbContext context)
    {

        var foodEntry = await context.FoodEntries
            .Include(fe => fe.Food)
            .FirstOrDefaultAsync( fe => fe.FoodEntryId == id);

        if (foodEntry == null)
        {
            return Results.NotFound($"Food entry with id {id} not found.");
        }
        
        // Check if the Food is being referenced by other FoodEntries
        var isFoodReferencedElsewhere = await context.FoodEntries
            .AnyAsync(fe => fe.FoodId == foodEntry.FoodId && fe.FoodEntryId != id);
        
        if (!isFoodReferencedElsewhere)
        {
            // If not, delete the Food
            context.Foods.Remove(foodEntry.Food);
        }
        
        context.FoodEntries.Remove(foodEntry);
        await context.SaveChangesAsync();

        return Results.Ok($"FoodEntry with id {id} and its associated Food have been deleted.");
    }
}