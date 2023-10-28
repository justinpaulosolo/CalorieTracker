using System.Security.Claims;
using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Commands;

public static class CreateMealEntryEndpoints
{
    public static void CreateMealEntryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/meal-entries", async (CreateMealEntryCommand command, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            command.UserId = userId;
            var foodEntryId = await sender.Send(command);
        }).WithTags("MealEntries").RequireAuthorization();
    }
}