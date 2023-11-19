using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Account.Contracts;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class CreateAccount
{
    public class Command : IRequest<OperationResult<string>>
    {
        public string Username { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }

    internal sealed class Handler(UserManager<ApplicationUser> userManager) : IRequestHandler<Command, OperationResult<string>>
    {
        public async Task<OperationResult<string>> Handle(Command command, CancellationToken cancellationToken)
        {
            var user = new ApplicationUser()
            {
                UserName = command.Username,
                Email = command.Email
            };

            var result = await userManager.CreateAsync(user, command.Password);

            if (!result.Succeeded)
            {
                return new OperationResult<string>
                {
                    Errors = result.Errors.Select(e => e.Description).ToList()
                };
            }

            return new OperationResult<string> { Result = user.Id };
        }
    }
}

public class CreateAccountEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/account/register", async (CreateAccountRequest request, ISender sender) =>
        {
            var command = new CreateAccount.Command()
            {
                Username = request.Username,
                Email = request.Email,
                Password = request.Password
            };

            var result = await sender.Send(command);

            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account");
    }
}