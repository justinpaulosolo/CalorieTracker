using CalorieTracker.Server.Features.Meals;

namespace CalorieTracker.Server.Entities;

public class FoodEntry
{
    public int FoodEntryId { get; set; }
    public int MealId { get; set; } // Foreign Key referencing Meals Table
    public Meal Meal { get; set; } = default!;
    public int FoodId { get; set; } // Foreign Key referencing Foods Table
    public Food Food { get; set; } = default!;
    public int Quantity { get; set; }
}
