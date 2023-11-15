using MediatR;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.MacrosGoals.Commands;

public static class CreateMacroGoalEndpoints
{
    public static void CreateMacroGoalEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/macro-goal", async (CreateMacroGoalCommand command, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            command.UserId = userId;
            var result = await sender.Send(command);
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Macro Goal").RequireAuthorization();
    }
}
