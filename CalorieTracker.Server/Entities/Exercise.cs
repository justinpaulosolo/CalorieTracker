namespace CalorieTracker.Server.Entities;

public class Exercise
{
    public int ExerciseId { get; set; }
    public string Name { get; set; } = default!;    
    public int ExerciseTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public ExerciseType ExerciseType { get; set; } = default!;
}
