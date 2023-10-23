namespace CalorieTracker.Server.Entities;

public class Meal
{
    public int MealId { get; set; }
    public string UserId { get; set; } // Foreign Key referencing Identity User
    public DateTime Date { get; set; }
    public string MealType { get; set; } // Breakfast, Lunch, Dinner
    public List<FoodEntry> FoodEntries { get; set; }
}