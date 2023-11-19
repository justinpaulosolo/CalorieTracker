using CalorieTracker.Server.Entities;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class Logout
{
    public sealed class Command : IRequest
    {

    }

    internal sealed class Handler(SignInManager<ApplicationUser> signInManager) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            await signInManager.SignOutAsync();
        }
    }
}

public class LogoutEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/account/manage/logout", async (ISender sender) =>
        {
            var command = new Logout.Command();
            await sender.Send(command);
        }).WithTags("Account").RequireAuthorization();
    }
}