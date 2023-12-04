namespace CalorieTracker.Server.Models.Food;

public class FoodDto
{
    public int FoodId { get; set; }
    public int FoodDiaryEntryId { get; set; }
    public string Name { get; set; } = null!;
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public double Calories { get; set; }
}