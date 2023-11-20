namespace CalorieTracker.Server.Features.Meals.Contracts;

public record GetMealsTotalMacrosByDateResponse(
    DateTime Date,
    long TotalProteins,
    long TotalCarbs,
    long TotalFats,
    long TotalCalories
);
