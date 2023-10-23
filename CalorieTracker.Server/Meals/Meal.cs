using CalorieTracker.Server.FoodEntries;

namespace CalorieTracker.Server.Meals;

public class Meal
{
    public int MealId { get; set; }
    public string UserId { get; set; } // Foreign Key referencing Identity User
    public DateTime Date { get; set; }
    public string MealType { get; set; } // Breakfast, Lunch, Dinner
    public List<FoodEntry> FoodEntries { get; set; }
}

public class CreateMealRequest
{
    public string UserId { get; set; }
    public string MealType { get; set; }
}