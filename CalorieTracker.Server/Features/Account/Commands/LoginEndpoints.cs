using MediatR;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class LoginEndpoints
{
    public static void LoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/account/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account");
    }
}