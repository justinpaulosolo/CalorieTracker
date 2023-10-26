using System.ComponentModel.DataAnnotations;
using CalorieTracker.Server.Features.FoodEntries;

namespace CalorieTracker.Server.Features.Meals;

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
    public string UserId { get; set; } = default!;
    [Required]
    public string MealType { get; set; } = default!;
    [Required]
    public DateTime Date { get; set; } = default!;
}