namespace CalorieTracker.Server.Features.MealEntries.Read;

public class GetMealEntriesByDateAndTypeResponse
{
    public int FoodId { get; set; }
    public string FoodName { get; set; } = string.Empty;
    public int Proteins { get; set; }
    public int Carbs { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
    public int FoodEntryId { get; set; }
    public int MealId { get; set; }
}