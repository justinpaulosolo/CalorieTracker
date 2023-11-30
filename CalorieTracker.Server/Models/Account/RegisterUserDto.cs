namespace CalorieTracker.Server.Models.Account;

public class RegisterDto
{
    public string Username { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}
