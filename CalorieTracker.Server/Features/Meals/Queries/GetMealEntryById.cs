using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealEntryByIdEndpoint
{
    public static void MapGetMealEntryByIdEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/meals/{foodEntryId}", async (int foodEntryId, ISender sender) =>
        {
            var query = new GetMealEntryByIdQuery { FoodEntryId = foodEntryId };
            var mealEntry = await sender.Send(query);
            if (mealEntry != null)
            {
                return Results.Ok(mealEntry);
            }
            return Results.NotFound();
        }).WithTags("Meal Entries").RequireAuthorization();
    }
}
public class GetMealEntryByIdResponse
{
    public int FoodMealEntryId { get; set; }
    public string MealType { get; set; } = default!;
    public string FoodName { get; set; } = default!;
    public int Proteins { get; set; }
    public int Carbs { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
}

public class GetMealEntryByIdQuery : IRequest<GetMealEntryByIdResponse?>
{
    public int FoodEntryId { get; set; }
}

public class GetMealEntryHandler(ApplicationDbContext dbContext) : IRequestHandler<GetMealEntryByIdQuery, GetMealEntryByIdResponse?>
{
    private readonly ApplicationDbContext _dbContext = dbContext;

    public async Task<GetMealEntryByIdResponse?> Handle(GetMealEntryByIdQuery request, CancellationToken cancellationToken)
    {
        var foodEntry = await _dbContext.MealFoodEntries
            .Include(fe => fe.Meal)
            .Include(fe => fe.Food)
            .FirstOrDefaultAsync(fe => fe.Id == request.FoodEntryId, cancellationToken);

        if (foodEntry == null)
        {
            return null;
        }

        return new GetMealEntryByIdResponse
        {
            FoodMealEntryId = foodEntry.Id,
            MealType = foodEntry.Meal.MealType,
            FoodName = foodEntry.Food.Name,
            Proteins = foodEntry.Food.Proteins,
            Carbs = foodEntry.Food.Carbs,
            Fats = foodEntry.Food.Fats,
            Calories = foodEntry.Food.Calories,
        };
    }
}
