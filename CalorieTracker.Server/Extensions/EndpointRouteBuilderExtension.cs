using CalorieTracker.Server.EndpointHandlers;

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
            .WithSummary("Register a new user")
            .WithDescription("Registers a new user in the system");

        accountEndpoints.MapPost("/login", AccountHandlers.LoginAsync)
            .WithSummary("Login a user")
            .WithDescription("Logs in a user in the system");
        
        accountEndpoints.MapPost("/logout", AccountHandlers.LogoutAsync)
            .RequireAuthorization()
            .WithSummary("Logout a user")
            .WithDescription("Logs out a user in the system");

        accountEndpoints.MapGet("/user", AccountHandlers.GetUserDetails)
            .RequireAuthorization()
            .WithSummary("Get user details")
            .WithDescription("Gets the details of the current user");

        return accountEndpoints;
    }

    public static RouteGroupBuilder RegisterFoodDiaryEndpoints(
        this IEndpointRouteBuilder endpoints)
    {
        var foodDiaryEndpoints = endpoints.MapGroup("/api/diary/food");
        foodDiaryEndpoints.WithTags("FoodDiary");
        foodDiaryEndpoints.WithOpenApi();
        foodDiaryEndpoints.RequireAuthorization();

        foodDiaryEndpoints.MapPost("/", FoodDiaryHandlers.CreateFoodDiaryAsync)
            .WithSummary("Create a food diary entry")
            .WithDescription("Creates a food diary entry for the current user");
        
        foodDiaryEndpoints.MapGet("/{foodDiaryId:int}", FoodDiaryHandlers.GetFoodDiaryByIdAsync)
            .WithSummary("Get a food diary entry by ID")
            .WithDescription("Retrieves a food diary entry for the current user by ID");
        
        return foodDiaryEndpoints;
    }

    public static RouteGroupBuilder RegisterDiaryEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var diaryEndpoints = endpoints.MapGroup("/api/diary");
        diaryEndpoints.WithTags("Diary");
        diaryEndpoints.WithOpenApi();
        diaryEndpoints.RequireAuthorization();
        
        diaryEndpoints.MapGet("/{date:datetime}", DiaryHandlers.GetFoodDiaryByDateAsync)
            .WithSummary("Get a diary entry by date")
            .WithDescription("Retrieves a diary entry for the current user by date");

        return diaryEndpoints;
    }

}
