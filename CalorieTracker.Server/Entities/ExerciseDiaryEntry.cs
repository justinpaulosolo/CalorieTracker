namespace CalorieTracker.Server.Entities;

public class ExerciseDiaryEntry
{
    public int ExerciseDiaryEntryId { get; set; }
    public int ExerciseDiaryId { get; set; }
    public int ExerciseTypeId { get; set; }
    
    public ExerciseType ExerciseType { get; set; }
    public ExerciseDiary ExerciseDiary { get; set; }
}
