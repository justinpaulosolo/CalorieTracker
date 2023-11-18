using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Commands;
public static class CreateMealEntryEndpoint
{ 
    public static void MapCreateMealEntryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/meal-entries", async (CreateMealEntryCommand command, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            command.UserId = userId;
            var foodEntryId = await sender.Send(command);
        }).WithTags("Meal Entries").RequireAuthorization();
    }
}

public sealed class CreateMealEntryCommand : IRequest<int>
{
    public string UserId { get; set; } = null!;
    public string MealType { get; init; } = null!;
    public DateTime Date { get; init; }
    public string Name { get; init; } = null!;
    public int Proteins { get; init; }
    public int Carbs { get; init; }
    public int Fats { get; init; }
    public int Calories { get; init; }
    public int Quantity { get; init; }
}

public class CreateMealEntryHandler
    (ApplicationDbContext dbContext) : IRequestHandler<CreateMealEntryCommand, int>
{
    public async Task<int> Handle(CreateMealEntryCommand command, CancellationToken cancellationToken)
    {
        var meal = await GetOrCreateMeal(command, cancellationToken);
        var food = await GetOrCreateFood(command, cancellationToken);

        var foodEntry = new FoodEntry
        {
            MealId = meal.MealId, FoodId = food.FoodId, Quantity = command.Quantity
        };

        dbContext.FoodEntries.Add(foodEntry);
        await dbContext.SaveChangesAsync(cancellationToken);

        return foodEntry.FoodEntryId;
    }

    private async Task<Meal> GetOrCreateMeal(CreateMealEntryCommand command, CancellationToken cancellationToken)
    {
        var existingMeal = await dbContext.Meals.Where(m =>
                m.UserId == command.UserId && m.Date.Date == command.Date.Date && m.MealType == command.MealType)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (existingMeal != null)
        {
            return existingMeal;
        }

        var meal = new Meal
        {
            UserId = command.UserId, MealType = command.MealType, Date = command.Date
        };

        dbContext.Meals.Add(meal);
        await dbContext.SaveChangesAsync(cancellationToken);
        return meal;
    }

    private async Task<Food> GetOrCreateFood(CreateMealEntryCommand command, CancellationToken cancellationToken)
    {
        var existingFood = await dbContext.Foods.FirstOrDefaultAsync(f =>
            f.Name == command.Name && f.Proteins == command.Proteins && f.Carbs == command.Carbs &&
            f.Fats == command.Fats && f.Calories == command.Calories, cancellationToken: cancellationToken);

        if (existingFood != null)
        {
            return existingFood;
        }

        var food = new Food
        {
            Name = command.Name,
            Proteins = command.Proteins,
            Carbs = command.Carbs,
            Fats = command.Fats,
            Calories = command.Calories
        };

        dbContext.Foods.Add(food);
        await dbContext.SaveChangesAsync(cancellationToken);
        return food;
    }
}