namespace CalorieTracker.Server.Models.NutritionGoal;

public class UpdateNutritionGoalDto
{
    public int NutritionGoalId { get; set; }
    public int Calories { get; set; }
    public int Protein { get; set; }
    public int Carbs { get; set; }
    public int Fat { get; set; }
}