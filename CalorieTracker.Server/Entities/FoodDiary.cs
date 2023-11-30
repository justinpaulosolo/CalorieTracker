namespace CalorieTracker.Server.Entities;

public class FoodDiary
{
    public int FoodDiaryId { get; set; }
    public int DiaryId { get; set; }
    public int MealTypeId { get; set; }
    public ICollection<FoodDiaryEntry> FoodDiaryEntries { get; set; }

    // Navigation properties
    public Diary Diary { get; set; }
}
