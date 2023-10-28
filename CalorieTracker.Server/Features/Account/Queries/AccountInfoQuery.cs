using System.Security.Claims;
using CalorieTracker.Server.Common;
using MediatR;

namespace CalorieTracker.Server.Features.Account.Queries;

public sealed class AccountInfoQuery : IRequest<OperationResult<AccountInfoResponse>>
{
    public ClaimsPrincipal? User { get; set; }
}