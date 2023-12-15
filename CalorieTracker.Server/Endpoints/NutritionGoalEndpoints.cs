using CalorieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Endpoints;

public static class NutritionGoalEndpoints
{
    public static RouteGroupBuilder MapNutritionGoalEndpoints(this IEndpointRouteBuilder builder)
    {
        var nutritionGoalEndpoints = builder.MapGroup("/api/nutrition-goal");
        nutritionGoalEndpoints.WithTags("Nutrition Goal");
        nutritionGoalEndpoints.WithOpenApi();
        nutritionGoalEndpoints.RequireAuthorization();
        
        nutritionGoalEndpoints.MapPost("", NutritionGoalHandler.CreateNutritionGoalAsync)
            .WithSummary("Create a nutrition goal")
            .WithDescription("Creates a nutrition goal for the current user");
        
        nutritionGoalEndpoints.MapGet("", NutritionGoalHandler.GetNutritionGoalAsync)
            .WithSummary("Get a nutrition goal")
            .WithDescription("Retrieves a nutrition goal for the current user");
        
        nutritionGoalEndpoints.MapPut("/update", NutritionGoalHandler.UpdateNutritionGoalAsync)
            .WithSummary("Update a nutrition goal")
            .WithDescription("Updates a nutrition goal for the current user");
        
        return nutritionGoalEndpoints;
    }
}