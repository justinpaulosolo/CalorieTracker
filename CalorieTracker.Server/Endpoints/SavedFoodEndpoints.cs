using CalorieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Endpoints;

public static class SavedFoodEndpoints
{
    public static RouteGroupBuilder MapSavedFoodEndpoints(this IEndpointRouteBuilder builder)
    {
        var savedFoodEndpoints = builder.MapGroup("/api/saved-food");
        savedFoodEndpoints.WithTags("Saved Food");
        savedFoodEndpoints.WithOpenApi();
        savedFoodEndpoints.RequireAuthorization();

        savedFoodEndpoints.MapPost("/", SavedFoodHandlers.CreateSavedFoodAsync)
            .WithSummary("Create saved food")
            .WithDescription("Creates a new saved food for the current user");
        
        savedFoodEndpoints.MapGet("/", SavedFoodHandlers.GetAllSavedFoodsAsync)
            .WithSummary("Get saved foods")
            .WithDescription("Gets all saved foods for the current user");

        return savedFoodEndpoints;
    }
}