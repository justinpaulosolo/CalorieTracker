namespace CalorieTracker.Server.Features.Account.Contracts;

public record LoginResponse(
    string Id,
    string Username,
    string Email
);
