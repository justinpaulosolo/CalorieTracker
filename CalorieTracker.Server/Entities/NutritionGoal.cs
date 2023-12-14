namespace CalorieTracker.Server.Entities;

public class NutritionGoal
{
    public int NutritionGoalId { get; set; }
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }
    
    public string UserId { get; set; } = null!;
    public ApplicationUser User { get; set; } = null!;
}