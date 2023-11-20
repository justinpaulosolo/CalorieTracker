namespace CalorieTracker.Server.Features.Account.Contracts;

public record LoginRequest(
    string Username,
    string Password
);