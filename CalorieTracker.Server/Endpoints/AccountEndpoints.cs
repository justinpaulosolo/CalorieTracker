using CalorieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Endpoints;

public static class AccountEndpoints
{
    public static RouteGroupBuilder MapAccountEndpoints(this IEndpointRouteBuilder builder)
    {
        var accountEndpoints = builder.MapGroup("/api/account");
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

        accountEndpoints.MapPut("/update", AccountHandlers.UpdateAccount)
            .RequireAuthorization()
            .WithSummary("Update Account")
            .WithDescription("Updates accounts username and email");

        return accountEndpoints;
    }
}
