namespace CalorieTracker.Server.Entities;

public class NutritionGoal
{
    public int NutritionGoalId { get; set; }
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
    
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
}