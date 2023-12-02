using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Repository;

public interface IFoodDiaryEntryRepository
{
    public Task<FoodDiaryEntry?> GetFoodDiaryEntryByIdAsync(int foodDiaryEntryId);
    public Task<FoodDiaryEntry?> GetFoodDiaryEntryByFoodDiaryIdAsync(int foodDiaryId);
    public Task<FoodDiaryEntry> CreateFoodDiaryEntryAsync(FoodDiaryEntry foodDiaryEntry);
    public Task<FoodDiaryEntry> UpdateFoodDiaryEntryAsync(FoodDiaryEntry foodDiaryEntry);
    public Task DeleteFoodDiaryEntryAsync(FoodDiaryEntry foodDiaryEntry);
}