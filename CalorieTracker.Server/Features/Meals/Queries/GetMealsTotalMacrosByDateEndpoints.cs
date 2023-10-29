using System.Security.Claims;
using MediatR;

namespace CalorieTracker.Server.Features.Meals.Queries;

public static class GetMealsTotalMacrosByDateEndpoints
{
    public static void GetMealsTotalMacrosByDateEndpoint(this IEndpointRouteBuilder app)
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