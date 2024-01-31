namespace CalorieTracker.Server.Models.Account;

public class AccountDetailsDto
{
    public string UserId { get; set; } = default!;
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
