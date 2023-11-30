namespace CalorieTracker.Server.Extensions;

public static class EndpointRouteBuilderExtension
{
    public static RouteGroupBuilder RegisterFoodDiaryEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        var foodDiaryEndpoints = endpoints.MapGroup("/api/diary/");
        foodDiaryEndpoints.WithTags("FoodDiary");
        foodDiaryEndpoints.WithOpenApi();
        foodDiaryEndpoints.RequireAuthorization();

        foodDiaryEndpoints.MapPost("/food", FoodDiaryHandlers.CreateFoodDiaryAsync)
            .WithTags("FoodDiary")
            .WithSummary("Create a food diary entry")
            .WithDescription("Creates a food diary entry for the current user");

        return foodDiaryEndpoints;
    }

}
