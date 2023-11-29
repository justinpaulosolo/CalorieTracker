using CalorieTracker.Server.Data;
using CalorieTracker.Server.Features.Meals.Contracts;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealEntryById
{
    public class Query : IRequest<GetMealEntryByIdResponse?>
    {
        public int FoodEntryId { get; set; }
    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<Query, GetMealEntryByIdResponse?>
    {
        public async Task<GetMealEntryByIdResponse?> Handle(Query request, CancellationToken cancellationToken)
        {
            var foodEntry = await dbContext.MealFoodEntries
                .Include(fe => fe.Meal)
                .Include(fe => fe.Food)
                .FirstOrDefaultAsync(fe => fe.Id == request.FoodEntryId, cancellationToken);

            if (foodEntry == null)
            {
                return null;
            }

            return new GetMealEntryByIdResponse(
                foodEntry.Id,
                foodEntry.Meal.MealType,
                foodEntry.Food.Name,
                foodEntry.Food.Protein,
                foodEntry.Food.Carbohydrates,
                foodEntry.Food.Fat,
                foodEntry.Food.Calories,
                foodEntry.Meal.Date
            );
        }
    }
}

public class GetMealEntryByIdEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/meals/{foodEntryId:int}", async (int foodEntryId, ISender sender) =>
        {
            var query = new GetMealEntryById.Query()
            {
                FoodEntryId = foodEntryId
            };

            var mealEntry = await sender.Send(query);

            return mealEntry != null ? Results.Ok(mealEntry) : Results.NotFound();
        }).WithTags("Meals").RequireAuthorization();
    }
}
