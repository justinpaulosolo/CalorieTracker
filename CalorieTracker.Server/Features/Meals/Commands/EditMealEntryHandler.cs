using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Commands;

internal sealed class EditMealEntryHandler(ApplicationDbContext dbContext) : IRequestHandler<EditMealEntryCommand, int>
{
    public async Task<int> Handle(EditMealEntryCommand request, CancellationToken cancellationToken)
    {
        var foodEntry = await dbContext.FoodEntries
            .Include(fe => fe.Meal)
            .Include(fe => fe.Food)
            .FirstOrDefaultAsync(fe => fe.FoodEntryId == request.FoodEntryId, cancellationToken: cancellationToken);

        if (foodEntry == null)
        {
            throw new DirectoryNotFoundException(nameof(foodEntry));
        }

        var food = foodEntry.Food;
        food.Name = request.Name;
        food.Proteins = request.Proteins;
        food.Carbs = request.Carbs;
        food.Fats = request.Fats;
        food.Calories = request.Calories;

        var meal = await dbContext.Meals
            .FirstOrDefaultAsync(m => m.UserId == request.UserId
            && m.MealType == request.MealType
            && m.Date.Date == request.Date.Date, cancellationToken: cancellationToken);

        if (meal == null)
        {
            meal = new Meal
            {
                UserId = request.UserId,
                MealType = request.MealType,
                Date = request.Date,
            };
            dbContext.Meals.Add(meal);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        foodEntry.MealId = meal.MealId;

        await dbContext.SaveChangesAsync(cancellationToken);
        return foodEntry.FoodEntryId;
    }
}
