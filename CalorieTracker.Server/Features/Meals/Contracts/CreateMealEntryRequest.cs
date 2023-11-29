namespace CalorieTracker.Server.Features.Meals.Contracts;

public record CreateMealEntryRequest(
    string MealType,
    DateTime Date,
    string Name,
    int Proteins,
    int Carbohydrates,
    int Fats,
    int Calories,
    int Quantity
);
