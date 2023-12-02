namespace CalorieTracker.Server.Models.FoodDiaryEntry;

public class CreateFoodDiaryEntryDto
{
    public int MealTypeId { get; set; }
    public DateTime Date { get; set; }
    public string FoodName { get; set;} = default!;
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Fat { get; set; }
    public double Carbs { get; set; }
}