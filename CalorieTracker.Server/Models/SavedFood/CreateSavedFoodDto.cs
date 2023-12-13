namespace CalorieTracker.Server.Models.SavedFood;

public class CreateSavedFoodDto
{
    public string Name { get; set; } = default!;
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }
}