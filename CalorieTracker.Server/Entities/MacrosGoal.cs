namespace CalorieTracker.Server.Entities;

public class MacrosGoal
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int ProteinsGoal { get; set; }
    public int CarbohydratesGoal { get; set; }
    public int FatsGoal { get; set; }
    public int CaloriesGoal { get; set; }
    public ApplicationUser User { get; set; } = null!;
}
