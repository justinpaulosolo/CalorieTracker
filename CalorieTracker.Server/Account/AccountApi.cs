using CalorieTracker.Server.Users;
using Microsoft.AspNetCore.Identity;
using MiniValidation;
using System.Security.Claims;

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

                var result = await userManager.CreateAsync(user, registerUserRequest.Password);

                if(!result.Succeeded)
                {
                    return Results.BadRequest(result.Errors);
                }

                return Results.Ok(new { user.Id, user.UserName, user.Email });
            });

            group.MapPost("/login", async (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, LoginUserRequest loginUserRequest) =>
            {
                if (!MiniValidator.TryValidate(loginUserRequest, out var errors))
                {
                    return Results.ValidationProblem(errors);
                }

                var result = await signInManager.PasswordSignInAsync(loginUserRequest.Username, loginUserRequest.Password, true, false);

                if (!result.Succeeded)
                {
                    return Results.BadRequest(result);
                }

                return Results.Ok();
            });

            var accountGroup = group.MapGroup("/manage").RequireAuthorization();

            accountGroup.MapPost("/logout", async (SignInManager<ApplicationUser> signInManager) =>
            {
                await signInManager.SignOutAsync();
                return Results.Ok();
            });

            accountGroup.MapGet("/info", async (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ClaimsPrincipal claimsPrincipal) =>
            {
                if (await userManager.GetUserAsync(claimsPrincipal) is not { } user)
                {
                    return Results.NotFound();
                }

                return Results.Ok(await CreateInfoResponseAsync(user, claimsPrincipal, userManager));
            });


            return group;
        }

        private static async Task<UserInfo> CreateInfoResponseAsync(ApplicationUser user, ClaimsPrincipal claimsPrincipal, UserManager<ApplicationUser> userManager)
        {
            return new()
            {
                Id = await userManager.GetUserIdAsync(user),
                Username = await userManager.GetUserNameAsync(user) ?? throw new NotSupportedException("Users must have an username."),
                Email = await userManager.GetEmailAsync(user) ?? throw new NotSupportedException("Users must have an email.")
            };
        }
    }
}
