using MediatR;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.MacrosGoals.Queries;

public static class GetMacroGoalEndpoints
{
    public static void GetMacroGoalEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/macro-goal/", async (ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var query = new GetMacroGoalQuery { UserId = userId };
            var result = await sender.Send(query);
            return Results.Ok(result);
        }).WithTags("Macro Goal").RequireAuthorization();
    }
}
