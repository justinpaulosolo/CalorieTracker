using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MealEntries.GetByDateMeal;

public static class Endpoint
{
    public static WebApplication GetMealEntriesByDateMeal(this WebApplication app)
    {
        app.MapGet("api/meal-entries/{meal}/{date}", HandleAsync).RequireAuthorization();
        return app;
    }

    private static async Task<IResult> HandleAsync(string meal, DateTime date, ApplicationDbContext context)
    {
        var meals = await context.Meals
            .Where(m => m.Date.Date == date.Date && m.MealType == meal)
            .Select(m => new 
            {
                Foods = m.FoodEntries.Select(fe => new 
                {
                    fe.FoodId,
                    fe.Food.Name,
                    fe.Food.Proteins,
                    fe.Food.Carbs,
                    fe.Food.Fats,
                    fe.Food.Calories,
                    fe.FoodEntryId,
                    fe.MealId,
                }).ToList()
            })
            .ToListAsync();

        return Results.Ok(meals);
    }
}