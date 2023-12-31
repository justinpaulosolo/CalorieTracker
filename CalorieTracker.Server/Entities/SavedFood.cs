namespace CalorieTracker.Server.Entities;

public class SavedFood
{
    public int SavedFoodId { get; set; }
    public string Name { get; set; } = default!;
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    public double Calories { get; set; }
    
    public string UserId { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
}