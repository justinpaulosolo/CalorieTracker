namespace CalorieTracker.Server.Models.ExerciseDiary;

public class CreateExerciseDiaryDto
{
    public int ExerciseDiaryId { get; set; }
    public int DiaryId { get; set; }
    public int ExerciseTypeId { get; set; }
}
