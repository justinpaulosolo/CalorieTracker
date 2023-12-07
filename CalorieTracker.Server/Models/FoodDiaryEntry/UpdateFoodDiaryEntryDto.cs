namespace CalorieTracker.Server.Models.FoodDiaryEntry;

public class UpdateFoodDiaryEntryDto
{
    public string Meal { get; set; } = default!;
    public string Name { get; set; } = default!;
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public DateTime Date { get; set; }
}