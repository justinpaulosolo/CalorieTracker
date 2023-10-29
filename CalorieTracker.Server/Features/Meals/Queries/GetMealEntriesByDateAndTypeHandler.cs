using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Queries;

internal sealed class GetMealEntriesByDateAndTypeHandler(ApplicationDbContext dbContext) : IRequestHandler<
    GetMealEntriesByDateAndTypeQuery, GetMealEntriesByDateAndTypeResponse?>
{
    public async Task<GetMealEntriesByDateAndTypeResponse?> Handle(GetMealEntriesByDateAndTypeQuery request,
        CancellationToken cancellationToken)
    {
        var meal = await dbContext.Meals
            .Where(m => m.UserId == request.UserId && m.Date.Date == request.Date.Date &&
                        m.MealType == request.MealType)
            .Include(m => m.FoodEntries)
            .ThenInclude(fe => fe.Food)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (meal == null || meal.FoodEntries.Count == 0)
        {
            return null; // or throw an exception, or return a default response
        }

        var mealMacros = meal.CalculateTotalMacros();
        var mealResponse = new GetMealEntriesByDateAndTypeResponse
        {
            MealId = meal.MealId,
            MealType = meal.MealType,
            Foods = meal.FoodEntries.Select(fe => new FoodEntryResponse
            {
                FoodId = fe.FoodId,
                FoodName = fe.Food.Name,
                Proteins = fe.Food.Proteins,
                Carbs = fe.Food.Carbs,
                Fats = fe.Food.Fats,
                Calories = fe.Food.Calories,
                FoodEntryId = fe.FoodEntryId
            }).ToList(),
            TotalProteins = mealMacros.Proteins,
            TotalCarbs = mealMacros.Carbs,
            TotalFats = mealMacros.Fats,
            TotalCalories = mealMacros.Calories
        };

        return mealResponse;
    }
}