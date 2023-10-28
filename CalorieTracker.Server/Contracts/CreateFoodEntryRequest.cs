namespace CalorieTracker.Server.Contracts;

public class CreateFoodEntryRequest
{
    public int MealId { get; set; }
    public int FoodId { get; set; }
}