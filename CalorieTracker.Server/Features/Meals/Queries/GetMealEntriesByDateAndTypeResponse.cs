namespace CalorieTracker.Server.Features.Meals.Queries;

public class GetMealEntriesByDateAndTypeResponse
{
    public int MealId { get; set; }
    public string MealType { get; set; }
    public List<FoodEntryResponse> Foods { get; set; }
    public int TotalProteins { get; set; }
    public int TotalCarbs { get; set; }
    public int TotalFats { get; set; }
    public int TotalCalories { get; set; }
}

public class FoodEntryResponse
{
    public int FoodId { get; set; }
    public string FoodName { get; set; }
    public int Proteins { get; set; }
    public int Carbs { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
    public int FoodEntryId { get; set; }
}
