namespace CalorieTracker.Server.Features.Meals.Contracts;

public record GetMealEntriesByDateAndTypeResponse(
    int MealId,
    string MealType,
    List<FoodEntryResponse> Foods,
    int TotalProteins,
    int TotalCarbohydrates,
    int TotalFats,
    int TotalCalories
);

public record FoodEntryResponse(
    string MealType,
    int FoodId,
    string FoodName,
    int Proteins,
    int Carbohydrates,
    int Fats,
    int Calories,
    int FoodEntryId
);
