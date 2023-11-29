namespace CalorieTracker.Server.Features.Meals.Contracts;

public record EditMealEntryRequest(
    int MealFoodEntryId,
    string MealType,
    DateTime Date,
    string FoodName,
    int Proteins,
    int Carbohydrates,
    int Fats,
    int Calories,
    int Quantity
);
