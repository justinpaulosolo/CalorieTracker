using CalorieTracker.Server.Data;
using CalorieTracker.Server.Features.Meals.Contracts;
using CalorieTracker.Server.Features.Meals.Services;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealEntriesByDateAndType
{
    public class Query : IRequest<GetMealEntriesByDateAndTypeResponse?>
    {
        public string UserId { get; set; } = string.Empty;

        public DateTime Date { get; set; }

        public string MealType { get; set; } = string.Empty;
    }

    internal sealed class Handler(ApplicationDbContext dbContext,
        IMealMacrosCalculator mealMacrosCalculator) : IRequestHandler<Query, GetMealEntriesByDateAndTypeResponse?>
    {
        public async Task<GetMealEntriesByDateAndTypeResponse?> Handle(Query request,
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

            var (proteins, carbs, fats, calories) = mealMacrosCalculator.CalculateTotalMacros(meal);
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
                TotalProteins = proteins,
                TotalCarbs = carbs,
                TotalFats = fats,
                TotalCalories = calories
            };

            return mealResponse;
        }
    }
}

public class GetMealEntriesByDateAndTypeEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/meals/{date:datetime}/{mealType}",
            async (DateTime date, string mealType, ISender sender, ClaimsPrincipal user) =>
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

                var query = new GetMealEntriesByDateAndType.Query()
                {
                    UserId = userId,
                    Date = date,
                    MealType = mealType
                };

                var result = await sender.Send(query);

                return Results.Ok(result);
            }).WithTags("Meals").RequireAuthorization();
    }
}