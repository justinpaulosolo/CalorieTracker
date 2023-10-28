using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Commands;

internal sealed class CreateAccountHandler(UserManager<ApplicationUser> userManager) : IRequestHandler<CreateAccountCommand, OperationResult<string>>
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