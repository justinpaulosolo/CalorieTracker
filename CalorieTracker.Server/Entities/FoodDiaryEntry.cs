namespace CalorieTracker.Server.Entities;

public class FoodDiaryEntry
{
    public int FoodDiaryEntryId { get; set; }
    public int FoodDiaryId { get; set; }
    public int FoodId { get; set; }
    
    // Navigation Properties
    public FoodDiary FoodDiary { get; set; } = null!;
    public Food Food { get; set; } = null!;
}