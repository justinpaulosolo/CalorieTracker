namespace CalorieTracker.Server.Entities;

public class UserMeal
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!; // Foreign Key referencing Identity User
    public DateTime Date { get; set; }
    public string MealType { get; set; } = default!;// Breakfast, Lunch, Dinner 
    public List<MealFoodEntry> FoodEntries { get; set; } = new List<MealFoodEntry>();
}
