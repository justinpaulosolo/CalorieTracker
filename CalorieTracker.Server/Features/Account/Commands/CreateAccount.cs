using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class CreateAccountEndpoint
{
    public static void MapCreateAccountEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/account/register", async (CreateAccountCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account");
    }
}
public sealed class CreateAccountCommand : IRequest<OperationResult<string>>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class CreateAccountHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<CreateAccountCommand, OperationResult<string>>
{
    public async Task<OperationResult<string>> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        var user = new ApplicationUser()
        {
            UserName = command.Username,
            Email = command.Email
        };

        var result = await userManager.CreateAsync(user, command.Password);

        if(!result.Succeeded)
        {
            return new OperationResult<string>
            {
                Errors = result.Errors.Select(e => e.Description).ToList()
            };
        }

        return new OperationResult<string> { Result = user.Id };
    }
    
}