using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Meals;

public static class MealsApi
{
    public static RouteGroupBuilder MapMeals(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/Meals");
        group.WithTags("Meals");
        group.MapPost("/", async (ApplicationDbContext context, Meal meal) =>
        {
            var existingMeal = await context.Meals
                .Where(m => m.UserId == meal.UserId && m.Date.Date == meal.Date.Date && m.MealType == meal.MealType)
                .FirstOrDefaultAsync();

            if (existingMeal != null)
            {
                return Results.BadRequest("A meal of this type already exists for this user on this day.");
            }

            context.Meals.Add(meal);
            await context.SaveChangesAsync();
            return Results.Created($"/api/meals{meal.MealId}", meal);
        });
        return group;
    }
}