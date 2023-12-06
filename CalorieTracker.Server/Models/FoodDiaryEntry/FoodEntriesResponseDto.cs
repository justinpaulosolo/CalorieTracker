namespace CalorieTracker.Server.Models.FoodDiaryEntry;

public class FoodEntriesResponseDto
{
    public List<Entities.Food> Data { get; set; } = new();
}