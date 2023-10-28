﻿using CalorieTracker.Server.Common;
using MediatR;

namespace CalorieTracker.Server.Features.Account.Commands;

public sealed class CreateAccountCommand : IRequest<OperationResult<string>>
{
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}