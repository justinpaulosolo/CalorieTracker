namespace CalorieTracker.Server.Models.Food;

public class FoodDto
{
    public int FoodId { get; set; }
    public string Name { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public double Calories { get; set; }
}