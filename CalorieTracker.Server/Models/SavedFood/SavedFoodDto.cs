namespace CalorieTracker.Server.Models.SavedFood;

public class SavedFoodDto
{
    public int SavedFoodId { get; set; }
    public string Name { get; set; } = default!;
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public double Calories { get; set; }
}