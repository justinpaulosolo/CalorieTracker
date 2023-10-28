using MediatR;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class LogoutEndpoints
{
    public static void LogoutEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/account/manage/logout", async (LogoutCommand command,  ISender sender ) =>
        {
            await sender.Send(command);
        }).WithTags("Account").RequireAuthorization();
    }
}