using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class LoginEndpoint
{
    public static void MapLoginEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/account/login", async (LoginCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account");
    }
}
public class LoginResponse
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public sealed class LoginCommand : IRequest<OperationResult<LoginResponse>>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginHandler
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