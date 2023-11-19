namespace CalorieTracker.Server.Features.MacrosGoals.Contracts;

public class GetMacroGoalResponse
{
    public int Id { get; set; }

    public int ProteinGoal { get; set; }

    public int CarbsGoal { get; set; }

    public int FatGoal { get; set; }

    public int CaloriesGoal { get; set; }
}
