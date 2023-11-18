using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Features.Meals.Services
{
    public interface IMealMacrosCalculator
    {
        (int Proteins, int Carbs, int Fats, int Calories) CalculateMacros(MealFoodEntry foodEntry);
        (int Proteins, int Carbs, int Fats, int Calories) CalculateTotalMacros(UserMeal meal);
    }
}