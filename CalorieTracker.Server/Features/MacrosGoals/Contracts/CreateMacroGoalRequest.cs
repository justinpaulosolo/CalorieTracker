namespace CalorieTracker.Server.Features.MacrosGoals.Contracts;

public record CreateMacroGoalRequest(
    string UserId,
    int ProteinGoal,
    int CarbsGoal,
    int FatsGoal,
    int CaloriesGoal
);
