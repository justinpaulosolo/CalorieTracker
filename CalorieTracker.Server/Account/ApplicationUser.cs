using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Users
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class UserInfo
    {
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
    }
}
