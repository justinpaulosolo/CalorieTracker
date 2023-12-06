using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.FoodDiaryEntry;

namespace CalorieTracker.Server.Services;

public interface IFoodDiaryEntryService
{
    public Task<int> CreateFoodDiaryEntryAsync(CreateFoodDiaryEntryDto createFoodDiaryEntryDto, DateTime date, string meal, string userId);
    public Task<List<Food>> GetDiaryFoodsByDate(DateTime date, string userId);
    public Task<bool> DeleteFoodDiaryEntryByIdAsync(int foodDiaryEntryId, string userId);
}