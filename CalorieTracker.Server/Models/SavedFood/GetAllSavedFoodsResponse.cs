namespace CalorieTracker.Server.Models.SavedFood;

public class GetAllSavedFoodsResponse
{
    public List<SavedFoodDto> SavedFoods { get; set; } = default!;
}