namespace CalorieTracker.Server.Extensions;

public static class EndpointRouteBuilderExtension
{
    public static RouteGroupBuilder RegisterAccountEndpoints(
        this IEndpointRouteBuilder endpointRouteBuilder)
    {
        var accountEndpoints = endpointRouteBuilder.MapGroup("/api/account");
        accountEndpoints.WithTags("Account");
        accountEndpoints.WithOpenApi();

        accountEndpoints.MapPost("/register", AccountHandlers.RegisterAsync)
            .WithTags("Account")
            .WithSummary("Register a new user")
            .WithDescription("Registers a new user in the system");

        accountEndpoints.MapPost("/login", AccountHandlers.LoginAsync)
            .WithTags("Account")
            .WithSummary("Login a user")
            .WithDescription("Logs in a user in the system");

        return accountEndpoints;
    }

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
