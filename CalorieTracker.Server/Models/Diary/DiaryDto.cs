using CalorieTracker.Server.Models.FoodDiary;

namespace CalorieTracker.Server.Models.Diary;

public class DiaryDto
{
    public int DiaryId { get; set; }
    public string UserId { get; set; } = null!;
    public DateTime Date { get; set; }
    public ICollection<FoodDiaryDto> FoodDiaries { get; set; } = new List<FoodDiaryDto>();
}