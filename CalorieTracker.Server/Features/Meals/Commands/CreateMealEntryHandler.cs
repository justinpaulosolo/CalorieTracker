using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Commands;

internal sealed class CreateMealEntryHandler
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