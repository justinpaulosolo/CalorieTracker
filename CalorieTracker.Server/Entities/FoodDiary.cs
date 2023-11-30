namespace CalorieTracker.Server;

public class FoodDiary
{
    public int FoodDiaryId { get; set; }
    public int DiaryId { get; set; }
    public int MealTypeId { get; set; }
    public ICollection<Food> Foods { get; set; } = new List<Food>();

    // Navigation properties
    public Diary Diary { get; set; }
}
