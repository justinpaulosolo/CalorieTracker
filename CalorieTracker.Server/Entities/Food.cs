namespace CalorieTracker.Server.Entities;

public class Food
{
    public int FoodId { get; set; }
    public string Name { get; set; } = null!;
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public double Calories { get; set; }
}
