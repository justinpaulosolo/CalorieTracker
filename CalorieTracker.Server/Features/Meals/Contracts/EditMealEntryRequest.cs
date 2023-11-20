namespace CalorieTracker.Server.Features.Meals.Contracts;

public record EditMealEntryRequest(
    int MealFoodEntryId,
    string MealType,
    DateTime Date,
    string Name,
    int Proteins,
    int Carbs,
    int Fats,
    int Calories,
    int Quantity
);
