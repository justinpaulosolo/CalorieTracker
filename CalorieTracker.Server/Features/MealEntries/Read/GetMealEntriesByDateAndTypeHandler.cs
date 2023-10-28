using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MealEntries.Read;

internal sealed class GetMealEntriesByDateAndTypeHandler(ApplicationDbContext dbContext) : IRequestHandler<
    GetMealEntriesByDateAndTypeQuery, List<GetMealEntriesByDateAndTypeResponse>>
{
    public async Task<List<GetMealEntriesByDateAndTypeResponse>> Handle(GetMealEntriesByDateAndTypeQuery query,
        CancellationToken cancellationToken)
    {
        var result = await dbContext.Meals
            .Where(m => m.Date.Date == query.Date.Date && m.MealType == query.MealType)
            .SelectMany(m => m.FoodEntries.Select(fe => new GetMealEntriesByDateAndTypeResponse
            {
                FoodId = fe.FoodId,
                FoodName = fe.Food.Name,
                Proteins = fe.Food.Proteins,
                Carbs = fe.Food.Fats,
                Calories = fe.Food.Calories,
                FoodEntryId = fe.FoodEntryId,
                MealId = fe.MealId,
            })).ToListAsync(cancellationToken: cancellationToken);
        return result;
    }
}