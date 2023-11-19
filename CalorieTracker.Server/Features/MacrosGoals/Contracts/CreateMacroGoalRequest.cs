namespace CalorieTracker.Server.Features.MacrosGoals.Contracts;

public class CreateMacroGoalRequest
{
    public string UserId { get; set; } = default!;

    public int ProteinGoal { get; set; }

    public int CarbsGoal { get; set; }

    public int FatsGoal { get; set; }

    public int CaloriesGoal { get; set; }
}
