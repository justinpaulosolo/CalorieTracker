using CalorieTracker.Server.Models.Food;

namespace CalorieTracker.Server.Models.FoodDiaryEntry;

public class FoodEntriesResponseDto
{
    public List<FoodDto> Data { get; set; } = [];
}