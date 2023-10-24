using CalorieTracker.Server.Users;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Account
{
    public static class AccountApi
    {
        public static RouteGroupBuilder MapAccount(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/Account");
            group.WithTags("Account");
            group.MapIdentityApi<ApplicationUser>();
            group.MapPost("/logout", async (SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            }).RequireAuthorization();
            return group;
        }
    }
}
