namespace CalorieTracker.Server.Entities;

public class SavedFoodItem
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int FoodId { get; set; }

    // Navigation properties
    public ApplicationUser User { get; set; } = null!;
    public Food Food { get; set; } = null!;
}