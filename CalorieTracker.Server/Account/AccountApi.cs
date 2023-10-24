using CalorieTracker.Server.Users;
using Microsoft.AspNetCore.Identity;
using MiniValidation;

namespace CalorieTracker.Server.Account
{
    public static class AccountApi
    {
        public static RouteGroupBuilder MapAccount(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/Account");

            group.WithTags("Account");

            group.MapPost("/register", async (UserManager<ApplicationUser> userManager, RegisterUserRequest registerUserRequest) =>
            {
                if (!MiniValidator.TryValidate(registerUserRequest, out var errors))
                {
                    return Results.ValidationProblem(errors);
                }

                var user = new ApplicationUser()
                {
                    UserName = registerUserRequest.Username,
                    Email = registerUserRequest.Email
                };

                var result = await userManager.CreateAsync(user);

                if(!result.Succeeded)
                {
                    return Results.BadRequest(result.Errors);
                }

                return Results.Ok(new { user.Id, user.UserName, user.Email });
            });

            group.MapPost("/logout", async (SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            }).RequireAuthorization();
            return group;
        }
    }
}
