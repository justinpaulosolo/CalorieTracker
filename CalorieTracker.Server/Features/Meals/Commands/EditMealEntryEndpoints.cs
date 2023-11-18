using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Server.Features.Meals.Commands;

public static class EditMealEntryEndpoints
{
    public static void EditMealEntryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPut("/meal-entries/edit/{foodEntryId}", async (int foodEntryId, EditMealEntryCommand command, [FromServices] IMediator mediator) =>
        {
            command.FoodEntryId = foodEntryId;
            var result = await mediator.Send(command);
            return Results.Ok(result);
        }).WithTags("Meals").RequireAuthorization();
    }
}
