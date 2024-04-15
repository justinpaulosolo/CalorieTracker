namespace CalorieTracker.Server.Entities;

public class SavedExercise
{
    public int SavedExerciseId { get; set; }
    public int ExerciseTypeId { get; set; }
    
    public string UserId { get; set; } = default!;
    public ApplicationUser User { get; set; } = default!;
}
