using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models;
using CalorieTracker.Server.Models.Food;
using CalorieTracker.Server.Models.FoodDiaryEntry;

namespace CalorieTracker.Server.Services;

public interface IFoodDiaryService
{
    public Task<int> CreateFoodDiaryEntryAsync(CreateFoodDiaryEntryDto createFoodDiaryEntryDto, string userId);
    public Task<int> UpdateFoodDiaryEntryAsync(UpdateFoodDiaryEntryDto updateFoodDiaryEntryDto, int foodDiaryEntryId, string userId);
    public Task<bool> DeleteFoodDiaryEntryByIdAsync(int foodDiaryEntryId, string userId);
    public Task<Diary?> GetFoodDiaryByDateAsync(DateTime date, string userId);
    public Task<List<FoodDto>> GetDiaryFoodsByDate(DateTime date, string userId);
    public Task<NutritionInfo?> GetNutritionInfoAsync(int diaryId);
    public Task<FoodDto> GetFoodDiaryEntryById(int foodDiaryEntryId);
}