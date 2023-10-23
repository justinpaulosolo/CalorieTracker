using CalorieTracker.Server.Data;
using MiniValidation;

namespace CalorieTracker.Server.Foods;

public static class FoodApi
{
    public static RouteGroupBuilder MapFoods(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/Foods");
        group.WithTags("Foods");
        group.MapPost("/", async (ApplicationDbContext context, CreateFoodRequest foodRequest) =>
        {
            if (!MiniValidator.TryValidate(foodRequest, out var errors))
            {
                return Results.ValidationProblem(errors);
            }
            
            var food = new Food()
            {
                Name = foodRequest.Name,
                Proteins = foodRequest.Proteins,
                Carbs = foodRequest.Carbs,
                Fats = foodRequest.Fats,
                Calories = foodRequest.Calories
            };
            
            context.Foods.Add(food);
            await context.SaveChangesAsync();

            return Results.Created($"/api/food/{food.FoodId}", food);
        });

        return group;
    }
    
}