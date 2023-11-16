using MediatR;

namespace CalorieTracker.Server.Features.MacrosGoals.Queries;

public class GetMacroGoalQuery : IRequest<GetMacroGoalResponse?>
{
    public string UserId { get; set; } = default!;
}