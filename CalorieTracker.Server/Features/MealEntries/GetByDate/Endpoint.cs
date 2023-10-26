using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MealEntries.GetByDate;

public static class Endpoint
{
    public static WebApplication GetMealEntriesByDate(this WebApplication app)
    {
        app.MapGet("api/meal-entries{date}", HandleAsync).RequireAuthorization();
        return app;
    }

    private static async Task<IResult> HandleAsync(DateTime date, ApplicationDbContext context)
    {
        var meals = await context.Meals
            .Where(m => m.Date.Date == date.Date)
            .Select(m => new 
            {
                MealType = m.MealType,
                Foods = m.FoodEntries.Select(fe => new 
                {
                    fe.Food.Name,
                    fe.Food.Proteins,
                    fe.Food.Carbs,
                    fe.Food.Fats,
                    fe.Food.Calories
                }).ToList()
            })
            .ToListAsync();

        return Results.Ok(meals);
    }
}