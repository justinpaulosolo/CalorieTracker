using CalorieTracker.Server.Common;
using MediatR;
using System.Diagnostics;

namespace CalorieTracker.Server.Features.MacrosGoals.Commands;

public class CreateMacroGoalCommand : IRequest<OperationResult<int>>
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int ProteinGoal {  get; set; }
    public int CarbsGoal {  get; set; }
    public int FatsGoal {  get; set; }
    public int CaloriesGoal {  get; set; }
}

