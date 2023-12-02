using CalorieTracker.Server.Models.FoodDiaryEntry;

namespace CalorieTracker.Server.Services;

public interface IFoodDiaryEntryService
{
    public Task<int> CreateFoodDiaryEntryAsync(CreateFoodDiaryEntryDto createFoodDiaryEntryDto, string userId);
}