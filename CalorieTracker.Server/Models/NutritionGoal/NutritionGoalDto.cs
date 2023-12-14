namespace CalorieTracker.Server.Models.NutritionGoal;

public class NutritionGoalDto
{
    public int NutritionGoalId { get; set; }
    public double Calories { get; set; }
    public double Protein { get; set; }
    public double Carbs { get; set; }
    public double Fat { get; set; }
}