using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MealEntries.Queries;

internal sealed class GetMealEntriesByDateAndTypeHandler(ApplicationDbContext dbContext) : IRequestHandler<
    GetMealEntriesByDateAndTypeQuery, List<GetMealEntriesByDateAndTypeResponse>>
{
    public async Task<List<GetMealEntriesByDateAndTypeResponse>> Handle(GetMealEntriesByDateAndTypeQuery request,
        CancellationToken cancellationToken)
    {
        var result = await dbContext.Meals
            .Where(m => m.UserId == request.UserId && m.Date.Date == request.Date.Date &&
                        m.MealType == request.MealType)
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