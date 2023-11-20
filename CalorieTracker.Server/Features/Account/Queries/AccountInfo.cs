using CalorieTracker.Server.Common;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Account.Contracts;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Account.Queries;

public static class AccountInfo
{
    public class Query : IRequest<OperationResult<AccountInfoResponse>>
    {
        public ClaimsPrincipal? User { get; set; }
    }

    internal sealed class Handler(UserManager<ApplicationUser> userManager) : IRequestHandler<Query, OperationResult<AccountInfoResponse>>
    {
        public async Task<OperationResult<AccountInfoResponse>> Handle(Query request, CancellationToken cancellationToken)
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
                Result = new AccountInfoResponse(
                    user!.Id,
                    user.Email!,
                    user.UserName!)
            };
        }
    }
}

public class AccountInfoEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/account/manage/info", async (ISender sender, ClaimsPrincipal user) =>
        {
            var result = await sender.Send(new AccountInfo.Query { User = user });

            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account").RequireAuthorization();
    }
}