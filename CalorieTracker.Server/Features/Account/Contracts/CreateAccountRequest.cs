namespace CalorieTracker.Server.Features.Account.Contracts;

public class CreateAccountRequest
{
    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;
}
