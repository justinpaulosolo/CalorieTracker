namespace CalorieTracker.Server.Features.Account.Contracts;

public record CreateAccountRequest(
    string Username,
    string Email,
    string Password
);