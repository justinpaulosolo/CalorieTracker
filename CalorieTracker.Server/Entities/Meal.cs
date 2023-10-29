namespace CalorieTracker.Server.Entities;

public class Meal
{
    public int MealId { get; set; }
    public string UserId { get; set; } = default!; // Foreign Key referencing Identity User
    public DateTime Date { get; set; }
    public string MealType { get; set; } = default!;// Breakfast, Lunch, Dinner 
    public List<FoodEntry> FoodEntries { get; set; } = new List<FoodEntry>();
    
    public (int Proteins, int Carbs, int Fats, int Calories) CalculateTotalMacros()
    {
        var totalProteins = 0;
        var totalCarbs = 0;
        var totalFats = 0;
        var totalCalories = 0;

        foreach (var macros in FoodEntries.Select(foodEntry => foodEntry.CalculateMacros()))
        {
            totalProteins += macros.Proteins;
            totalCarbs += macros.Carbs;
            totalFats += macros.Fats;
            totalCalories += macros.Calories;
        }

        return (totalProteins, totalCarbs, totalFats, totalCalories);
    }
}
