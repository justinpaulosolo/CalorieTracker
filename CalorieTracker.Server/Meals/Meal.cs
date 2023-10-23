using System.ComponentModel.DataAnnotations;
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
    [Required]
    public string UserId { get; set; }
    [Required]
    public string MealType { get; set; }
}