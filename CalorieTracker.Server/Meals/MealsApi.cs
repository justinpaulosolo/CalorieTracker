using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

namespace CalorieTracker.Server.Meals;

public static class MealsApi
{
    public static RouteGroupBuilder MapMeals(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/Meals");
        group.WithTags("Meals");
        group.MapPost("/", async (ApplicationDbContext context, CreateMealRequest mealRequest) =>
        {
            if (!MiniValidator.TryValidate(mealRequest, out var errors))
            {
                return Results.ValidationProblem(errors);
            }
            
            var existingMeal = await context.Meals
                .Where(m => m.UserId == mealRequest.UserId && m.Date.Date == new DateTime().Date && m.MealType == mealRequest.MealType)
                .FirstOrDefaultAsync();

            if (existingMeal != null)
            {
                return Results.BadRequest("A meal of this type already exists for this user on this day.");
            }

            var meal = new Meal()
            {
                UserId = mealRequest.UserId,
                MealType = mealRequest.MealType
            };

            context.Meals.Add(meal);
            await context.SaveChangesAsync();
            return Results.Created($"/api/meals{meal.MealId}", mealRequest);
        });
        return group;
    }
}