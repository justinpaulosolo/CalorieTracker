using CalorieTracker.Server.Data;
using CalorieTracker.Server.Features.Meals.Contracts;
using CalorieTracker.Server.Features.Meals.Services;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealsTotalMacrosByDate
{
    public class Query : IRequest<GetMealsTotalMacrosByDateResponse>
    {
        public DateTime Date { get; set; }

        public string UserId { get; set; } = default!;
    }

    internal sealed class Handler(ApplicationDbContext dbContext,
        IMealMacrosCalculator mealMacrosCalculator) : IRequestHandler<Query, GetMealsTotalMacrosByDateResponse>
    {
        public async Task<GetMealsTotalMacrosByDateResponse> Handle(Query request,
            CancellationToken cancellationToken)
        {
            // Get all meals for the user on the specified date
            var meals = await dbContext.UserMeals
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
            foreach (var (proteins, carbs, fats, calories) in meals.Select(mealMacrosCalculator.CalculateTotalMacros))
            {
                totalProteins += proteins;
                totalCarbs += carbs;
                totalFats += fats;
                totalCalories += calories;
            }

            // Create response
            var response = new GetMealsTotalMacrosByDateResponse(
                request.Date,
                totalProteins,
                totalCarbs,
                totalFats,
                totalCalories
            );

            return response;
        }
    }
}

public class GetMealsTotalMacrosByDateEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/meals/{date:datetime}/total-macros",
            async (DateTime date,
                ClaimsPrincipal user,
                ISender sender) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var query = new GetMealsTotalMacrosByDate.Query { UserId = userId, Date = date };
            var result = await sender.Send(query);

            return Results.Ok(result);
        }).WithTags("Meals").RequireAuthorization();
    }
}