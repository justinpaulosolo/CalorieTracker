using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.SavedFood;

namespace CalorieTracker.Server.Services;

public interface ISavedFoodService
{
    Task<int> CreateSavedFoodAsync(CreateSavedFoodDto createSavedFoodDto, string userId);
    Task<List<SavedFoodDto>> GetSavedFoodsAsync(string userId);
    Task<SavedFood?> GetSavedFoodByIdAsync(int savedFoodId, string userId);
    Task<bool> DeleteSavedFoodAsync(int savedFoodId, string userId);
}