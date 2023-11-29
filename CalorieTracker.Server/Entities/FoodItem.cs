namespace CalorieTracker.Server.Entities;

public class FoodItem
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Protein { get; set; }
    public int Carbohydrates { get; set; }
    public int Fat { get; set; }
    public int Calories { get; set; }
}
