using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class LogoutEndpoint
{
    public static void MapLogoutEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("/api/account/manage/logout", async (LogoutCommand command, ISender sender) =>
        {
            await sender.Send(command);
        }).WithTags("Account").RequireAuthorization();
    }
}

public sealed class LogoutCommand : IRequest
{

}

public class LogoutHandler(SignInManager<ApplicationUser> signInManager) : IRequestHandler<LogoutCommand>
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
    }
}