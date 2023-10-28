using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Features.Account.Queries;

internal sealed class AccountInfoHandler (UserManager<ApplicationUser> userManager) : IRequestHandler<AccountInfoQuery, OperationResult<AccountInfoResponse>>
{
    public async Task<OperationResult<AccountInfoResponse>> Handle(AccountInfoQuery request, CancellationToken cancellationToken)
    {
        if (request.User is null)
        {
            return await Task.FromResult(new OperationResult<AccountInfoResponse>
            {
                Errors = new List<string> { "User is not authenticated." }
            });
        }

        var user = await userManager.GetUserAsync(request.User);

        return new OperationResult<AccountInfoResponse>
        {
            Result = new AccountInfoResponse
            {
                Id = user!.Id,
                Email = user.Email!,
                Username = user.UserName!
            }
        };
    }
}