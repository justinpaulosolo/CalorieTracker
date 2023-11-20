namespace CalorieTracker.Server.Features.Meals.Contracts;

public record GetMealEntryByIdResponse(
    int FoodMealEntryId,
    string MealType,
    string FoodName,
    int Proteins,
    int Carbs,
    int Fats,
    int Calories
);
