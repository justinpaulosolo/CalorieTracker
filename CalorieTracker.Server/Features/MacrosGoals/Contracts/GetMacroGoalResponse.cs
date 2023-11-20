namespace CalorieTracker.Server.Features.MacrosGoals.Contracts;

public record GetMacroGoalResponse(
    int Id,
    int ProteinGoal,
    int CarbsGoal,
    int FatsGoal,
    int CaloriesGoal
);
