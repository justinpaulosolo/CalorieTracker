namespace CalorieTracker.Server.Entities;

public class FoodItem
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Proteins { get; set; }
    public int Carbohydrates { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
}
