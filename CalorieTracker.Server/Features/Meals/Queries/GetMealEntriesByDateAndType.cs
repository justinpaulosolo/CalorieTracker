using CalorieTracker.Server.Data;
using CalorieTracker.Server.Features.Meals.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealEntriesByDateAndTypeEndpoint
{
    public static void MapGetMealEntriesByDateAndTypeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/meals/{date}/{mealType}",
            async (DateTime date, string mealType, ISender sender, ClaimsPrincipal user) =>
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var query = new GetMealEntriesByDateAndTypeQuery { UserId = userId, Date = date, MealType = mealType };
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("Meal Entries").RequireAuthorization();
    }
}

public class GetMealEntriesByDateAndTypeResponse
{
    public int MealId { get; set; }
    public string MealType { get; set; } = default!;
    public List<FoodEntryResponse> Foods { get; set; } = default!;
    public int TotalProteins { get; set; }
    public int TotalCarbs { get; set; }
    public int TotalFats { get; set; }
    public int TotalCalories { get; set; }
}

public class FoodEntryResponse
{
    public int FoodId { get; set; }
    public string FoodName { get; set; } = default!;
    public int Proteins { get; set; }
    public int Carbs { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
    public int FoodEntryId { get; set; }
}

public class GetMealEntriesByDateAndTypeQuery : IRequest<GetMealEntriesByDateAndTypeResponse?>
{
    public string UserId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string MealType { get; set; } = string.Empty;
}

public class GetMealEntriesByDateAndTypeHandler(ApplicationDbContext dbContext, IMealMacrosCalculator mealMacrosCalculator) : IRequestHandler<
    GetMealEntriesByDateAndTypeQuery, GetMealEntriesByDateAndTypeResponse?>
{
    public async Task<GetMealEntriesByDateAndTypeResponse?> Handle(GetMealEntriesByDateAndTypeQuery request,
        CancellationToken cancellationToken)
    {
        var meal = await dbContext.UserMeals
            .Where(m => m.UserId == request.UserId && m.Date.Date == request.Date.Date &&
                        m.MealType == request.MealType)
            .Include(m => m.FoodEntries)
            .ThenInclude(fe => fe.Food)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        if (meal == null || meal.FoodEntries.Count == 0)
        {
            return null; // or throw an exception, or return a default response
        }

        var (Proteins, Carbs, Fats, Calories) = mealMacrosCalculator.CalculateTotalMacros(meal);
        var mealResponse = new GetMealEntriesByDateAndTypeResponse
        {
            MealId = meal.Id,
            MealType = meal.MealType,
            Foods = meal.FoodEntries.Select(fe => new FoodEntryResponse
            {
                FoodId = fe.FoodId,
                FoodName = fe.Food.Name,
                Proteins = fe.Food.Proteins,
                Carbs = fe.Food.Carbs,
                Fats = fe.Food.Fats,
                Calories = fe.Food.Calories,
                FoodEntryId = fe.Id
            }).ToList(),
            TotalProteins = Proteins,
            TotalCarbs = Carbs,
            TotalFats = Fats,
            TotalCalories = Calories
        };

        return mealResponse;
    }
}