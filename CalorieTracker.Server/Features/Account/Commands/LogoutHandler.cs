using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

internal sealed class LogoutHandler(SignInManager<ApplicationUser> signInManager) : IRequestHandler<LogoutCommand>
{
    private readonly SignInManager<ApplicationUser> _signInManager = signInManager;

    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        await _signInManager.SignOutAsync();
    }
}