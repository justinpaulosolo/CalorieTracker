using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Features.Meals.Services;

public class MealMacrosCalculator : IMealMacrosCalculator
{
    public (int Proteins, int Carbs, int Fats, int Calories) CalculateTotalMacros(UserMeal meal)
    {
        var totalProteins = 0;
        var totalCarbs = 0;
        var totalFats = 0;
        var totalCalories = 0;

        foreach (var foodEntry in meal.FoodEntries)
        {
            var macros = CalculateMacros(foodEntry);
            totalProteins += macros.Proteins;
            totalCarbs += macros.Carbs;
            totalFats += macros.Fats;
            totalCalories += macros.Calories;
        }

        return (totalProteins, totalCarbs, totalFats, totalCalories);
    }

    public (int Proteins, int Carbs, int Fats, int Calories) CalculateMacros(MealFoodEntry foodEntry)
    {
        return (foodEntry.Food.Proteins * foodEntry.Quantity, foodEntry.Food.Carbohydrates * foodEntry.Quantity, foodEntry.Food.Fats * foodEntry.Quantity, foodEntry.Food.Calories * foodEntry.Quantity);
    }
}
