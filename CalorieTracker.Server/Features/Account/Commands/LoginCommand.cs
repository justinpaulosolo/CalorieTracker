using CalorieTracker.Server.Common;
using MediatR;

namespace CalorieTracker.Server.Features.Account.Commands;

public sealed class LoginCommand : IRequest<OperationResult<LoginResponse>>
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}