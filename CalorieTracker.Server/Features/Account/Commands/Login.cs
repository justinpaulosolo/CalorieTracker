using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Account.Contracts;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class Login
{
    public class Command : IRequest<OperationResult<LoginResponse>>
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    internal sealed class Handler
    (
        SignInManager<ApplicationUser> signInManager,
        UserManager<ApplicationUser> userManager) : IRequestHandler<Command, OperationResult<LoginResponse>>
    {
        public async Task<OperationResult<LoginResponse>> Handle(Command request, CancellationToken cancellationToken)
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
}

public class LoginEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/account/login", async (LoginRequest request, ISender sender) =>
        {
            var command = new Login.Command()
            {
                Username = request.Username,
                Password = request.Password,
            };

            var result = await sender.Send(command);

            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account");
    }
}