namespace CalorieTracker.Server.Models.FoodDiary;

public class CreateFoodDiaryDto
{
    public int FoodDiaryId { get; set; }
    public int DiaryId { get; set; }
    public int MealTypeId { get; set; }
}
