using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Queries;

internal sealed class GetMealsTotalMacrosByDateHandler
    (ApplicationDbContext dbContext) : IRequestHandler<GetMealsTotalMacrosByDateQuery, GetMealsTotalMacrosByDateResponse>
{
    public async Task<GetMealsTotalMacrosByDateResponse> Handle(GetMealsTotalMacrosByDateQuery request,
        CancellationToken cancellationToken)
    {
        // Get all meals for the user on the specified date
        var meals = await dbContext.Meals
            .Where(m => m.UserId == request.UserId && m.Date.Date == request.Date.Date)
            .Include(m => m.FoodEntries)
            .ThenInclude(fe => fe.Food)
            .ToListAsync(cancellationToken: cancellationToken);

        // Initialize total macros
        var totalProteins = 0;
        var totalCarbs = 0;
        var totalFats = 0;
        var totalCalories = 0;

        // Calculate total macros
        foreach (var mealMacros in meals.Select(meal => meal.CalculateTotalMacros()))
        {
            totalProteins += mealMacros.Proteins;
            totalCarbs += mealMacros.Carbs;
            totalFats += mealMacros.Fats;
            totalCalories += mealMacros.Calories;
        }

        // Create response
        var response = new GetMealsTotalMacrosByDateResponse
        {
            Date = request.Date,
            TotalProteins = totalProteins,
            TotalCarbs = totalCarbs,
            TotalFats = totalFats,
            TotalCalories = totalCalories
        };

        return response;
    }
}