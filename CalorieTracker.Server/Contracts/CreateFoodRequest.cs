namespace CalorieTracker.Server.Contracts;

public class CreateFoodRequest
{
    public string Name { get; set; } = string.Empty;
    public int Proteins { get; set; }
    public int Carbs { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
}