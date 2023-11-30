using CalorieTracker.Server.Models.Food;

namespace CalorieTracker.Server.Models.FoodDiary;

public class FoodDiaryDto
{
    public int FoodDiaryId { get; set; }
    public int DiaryId { get; set; }
    public int MealTypeId { get; set; }
    public ICollection<FoodDto> Foods { get; set; }
}