using CalorieTracker.Server.Features.Foods;
using CalorieTracker.Server.Features.Meals;

namespace CalorieTracker.Server.Features.FoodEntries;

public class FoodEntry
{
    public int FoodEntryId { get; set; }
    public int MealId { get; set; } // Foreign Key referencing Meals Table
    public Meal Meal { get; set; }
    public int FoodId { get; set; } // Foreign Key referencing Foods Table
    public Food Food { get; set; }
    public int Quantity { get; set; }
}

public class CreateFoodEntryRequest
{
    public int MealId { get; set; }
    public int FoodId { get; set; }
    public int Quantity { get; set; }
}