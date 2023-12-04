namespace CalorieTracker.Server.Entities;

public class FoodDiaryEntry
{
    public int FoodDiaryEntryId { get; set; }
    public int FoodDiaryId { get; set; }
    public int FoodId { get; set; }
    
    public Food Food { get; set; }
}