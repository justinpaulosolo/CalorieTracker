using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Server.Users
{
    public class ApplicationUser : IdentityUser
    {
    }

    public class RegisterUserRequest
    {
        [Required]
        public string Username { get; set; } = default!;
        [Required]
        public string Email { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }

    public class LoginUserRequest
    {
        [Required]
        public string Username { get; set; } = default!;
        [Required]
        public string Password { get; set; } = default!;
    }

    public class UserInfo
    {
        public string Id { get; set; } = default!;
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
