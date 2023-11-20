namespace CalorieTracker.Server.Features.Meals.Contracts;

public record GetMealEntriesByDateAndTypeResponse(
    int MealId,
    string MealType,
    List<FoodEntryResponse> Foods,
    int TotalProteins,
    int TotalCarbs,
    int TotalFats,
    int TotalCalories
);

public record FoodEntryResponse(
    int FoodId,
    string FoodName,
    int Proteins,
    int Carbs,
    int Fats,
    int Calories,
    int FoodEntryId
);
