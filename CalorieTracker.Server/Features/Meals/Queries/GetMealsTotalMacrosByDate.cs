using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealsTotalMacrosByDateEndpoint
{
    public static void MapGetMealsTotalMacrosByDateEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/meals/{date}/total-macros", async (DateTime date, ClaimsPrincipal user, ISender sender) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var query = new GetMealsTotalMacrosByDateQuery { UserId = userId, Date = date };
            var result = await sender.Send(query);
            return Results.Ok(result);
        }).WithTags("Meals").RequireAuthorization();
    }
}

public class GetMealsTotalMacrosByDateResponse
{
    public DateTime Date { get; set; }
    public long TotalProteins { get; set; }
    public long TotalCarbs { get; set; }
    public long TotalFats { get; set; }
    public long TotalCalories { get; set; }
}

public class GetMealsTotalMacrosByDateQuery : IRequest<GetMealsTotalMacrosByDateResponse>
{
    public DateTime Date { get; set; }
    public string UserId { get; set; } = string.Empty;
}

public class GetMealsTotalMacrosByDateHandler
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