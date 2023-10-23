using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Users
{
    public static class UsersApi
    {
        public static RouteGroupBuilder MapUsers(this IEndpointRouteBuilder routes)
        {
            var group = routes.MapGroup("/users");
            group.WithTags("Users");

            group.MapPost("/", async Task<Results<Ok<string>, BadRequest>> (UserInfo newUser, UserManager<ApplicationUser> UserManager) =>
            {
                var user = new ApplicationUser()
                {
                    UserName = newUser.Username
                };
                var result = await UserManager.CreateAsync(user, newUser.Password);

                if (!result.Succeeded)
                {
                    return TypedResults.BadRequest();
                }
                return TypedResults.Ok(user.Id);
            });

            return group;
        }
    }
}
