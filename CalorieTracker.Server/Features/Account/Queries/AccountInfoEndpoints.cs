using System.Security.Claims;
using MediatR;

namespace CalorieTracker.Server.Features.Account.Queries;

public static class AccountInfoEndpoints
{
    public static void AccountInfoEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/account/manage/info", async (ISender sender, ClaimsPrincipal user) =>
        {
            var result = await sender.Send(new AccountInfoQuery{ User = user});
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account").RequireAuthorization();
    }
}