using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Account.Queries;

public static class AccountInfoEndpoint
{
    public static void MapAccountInfoEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/account/manage/info", async (ISender sender, ClaimsPrincipal user) =>
        {
            var result = await sender.Send(new AccountInfoQuery { User = user });
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account").RequireAuthorization();
    }
}

public class AccountInfoResponse
{
    public string Id { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public sealed class AccountInfoQuery : IRequest<OperationResult<AccountInfoResponse>>
{
    public ClaimsPrincipal? User { get; set; }
}

public class AccountInfoHandler (UserManager<ApplicationUser> userManager) : IRequestHandler<AccountInfoQuery, OperationResult<AccountInfoResponse>>
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