using CalorieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Endpoints;

public static class NutritionEndpoints
{
    public static RouteGroupBuilder MapNutritionEndpoints(this IEndpointRouteBuilder builder)
    {
        var nutritionEndpoints = builder.MapGroup("/api/nutrition");
        nutritionEndpoints.WithTags("Nutrition");
        nutritionEndpoints.WithOpenApi();
        nutritionEndpoints.RequireAuthorization();

        nutritionEndpoints.MapGet("/{date:datetime}", NutritionHandlers.GetNutritionInfoAsync)
            .WithSummary("Get nutrition info by date")
            .WithDescription("Retrieves nutrition information for the current user by date");

        return nutritionEndpoints;
    }    
}
