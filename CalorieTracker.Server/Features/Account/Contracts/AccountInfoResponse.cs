namespace CalorieTracker.Server.Features.Account.Contracts;

public record AccountInfoResponse(
    string Id,
    string Username,
    string Email
);
