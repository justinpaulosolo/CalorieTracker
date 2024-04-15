namespace CalorieTracker.Server.Entities;

public class ExerciseType
{
    public int ExerciseTypeId { get; set; }
    public string Name { get; set; } = default!;    
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
