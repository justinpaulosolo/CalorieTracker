using CalorieTracker.Server.Models.SavedFood;

namespace CalorieTracker.Server.Services;

public interface ISavedFoodService
{
    Task<int> CreateSavedFoodAsync(CreateSavedFoodDto createSavedFoodDto, string userId);
    Task<List<SavedFoodDto>> GetSavedFoodsAsync(string userId);
    Task<bool> DeleteSavedFoodAsync(int savedFoodId, string userId);
}