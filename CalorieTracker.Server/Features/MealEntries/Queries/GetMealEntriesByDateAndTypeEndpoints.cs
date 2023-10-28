using System.Security.Claims;
using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Queries;

public static class GetMealEntriesByDateAndTypeEndpoints
{
    public static void GetMealEntriesByDateAndTypeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/meal-entries/{date}/{mealType}",
            async (DateTime date, string mealType, ISender sender, ClaimsPrincipal user) =>
            {
                var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
                var query = new GetMealEntriesByDateAndTypeQuery { UserId = userId!, Date = date, MealType = mealType };
                var result = await sender.Send(query);
                return Results.Ok(result);
            }).WithTags("MealEntries").RequireAuthorization();
    }
}