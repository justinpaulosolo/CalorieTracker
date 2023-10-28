using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Delete;

public static class DeleteMealEntryEndpoints
{
    public static void DeleteMealEntryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("api/meal-entries/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteMealEntryCommand { Id = id });
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        });
    }
}