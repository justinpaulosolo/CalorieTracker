using System.ComponentModel.DataAnnotations;
using CalorieTracker.Server.Features.FoodEntries;

namespace CalorieTracker.Server.Features.Meals;

public class Meal
{
    public int MealId { get; set; }
    public string UserId { get; set; } = default!; // Foreign Key referencing Identity User
    public DateTime Date { get; set; }
    public string MealType { get; set; } = default!;// Breakfast, Lunch, Dinner 
    public List<FoodEntry> FoodEntries { get; set; } = new List<FoodEntry>();
}
