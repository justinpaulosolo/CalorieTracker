using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

internal sealed class LoginHandler
(
    SignInManager<ApplicationUser> signInManager,
    UserManager<ApplicationUser> userManager) : IRequestHandler<LoginCommand, OperationResult<LoginResponse>>
{
    public async Task<OperationResult<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var result = await signInManager.PasswordSignInAsync(request.Username, request.Password, true, false);

        if (!result.Succeeded)
        {
            return new OperationResult<LoginResponse>
            {
                Errors = new List<string> { "Invalid username or password." }
            };
        }

        var user = await userManager.FindByNameAsync(request.Username);
        
        return new OperationResult<LoginResponse>
        {
            Result = new LoginResponse
            {
                Id = user!.Id,
                Username = user.UserName!,
                Email = user.Email!
            }
        };
    }
}