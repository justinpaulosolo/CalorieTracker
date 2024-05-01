namespace CalorieTracker.Server.Entities;

public class Diary
{
    public int DiaryId { get; set; }
    public string UserId { get; set; } = default!;
    public DateTime Date { get; set; }
    public ICollection<FoodDiary> FoodDiaries { get; set; } = new List<FoodDiary>();
    public ICollection<ExerciseDiary> ExerciseDiaries { get; set; } = new List<ExerciseDiary>();
    
    public ApplicationUser User { get; set; }
}
