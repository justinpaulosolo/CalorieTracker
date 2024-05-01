namespace CalorieTracker.Server.Entities;

public class ExerciseDiary
{
    public int ExerciseDiaryId { get; set; }
    public int DiaryId { get; set; }
    public ICollection<ExerciseDiaryEntry> ExerciseDiaryEntries { get; set; } = new List<ExerciseDiaryEntry>();
    public Diary Diary { get; set; } = null!;
}
