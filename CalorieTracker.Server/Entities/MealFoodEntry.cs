namespace CalorieTracker.Server.Entities;

public class MealFoodEntry
{
    public int Id { get; set; }
    public int MealId { get; set; } // Foreign Key referencing Meals Table
    public UserMeal Meal { get; set; } = default!;
    public int FoodId { get; set; } // Foreign Key referencing Foods Table
    public FoodItem Food { get; set; } = default!;
    public int Quantity { get; set; }
}
