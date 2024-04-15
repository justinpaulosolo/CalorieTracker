using CalarieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Endpoints;

public static class ExerciseEndpoints
{
    public static RouteGroupBuilder MapExerciseEndpoints(this IEndpointRouteBuilder builder)
    {
        var exerciseEndpoints = builder.MapGroup("/api/exercise");
        exerciseEndpoints.WithTags("Exercise");
        exerciseEndpoints.WithOpenApi();
        exerciseEndpoints.RequireAuthorization();

        exerciseEndpoints.MapGet("/types", ExerciseHandlers.GetAllExerciseType)
            .WithSummary("Get all exercise types")
            .WithDescription("Retrieves all exercise types");

        return exerciseEndpoints;
    }
}
