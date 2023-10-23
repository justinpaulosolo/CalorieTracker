using CalorieTracker.Server.Users;

namespace CalorieTracker.Server.Account
{
    public static class AccountApi
    {
        public static RouteGroupBuilder MapAccount(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup("/Account");
            group.WithTags("Account");
            group.MapIdentityApi<ApplicationUser>();
            return group;
        }
    }
}
