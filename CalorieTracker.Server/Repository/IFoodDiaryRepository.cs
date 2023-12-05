using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Repository;

public interface IFoodDiaryRepository
{
    public Task<FoodDiary?> GetFoodDiaryByIdAsync(int foodDiaryId);
    public Task<List<FoodDiary>> GetFoodDiariesByDiaryId(int dairyId);
    public Task<FoodDiary?> GetFoodDiaryByDateAndMealTypeAsync(DateTime date, int mealType, string userId);
    public Task<FoodDiary> CreateFoodDiaryAsync(FoodDiary foodDiary);
    public Task<FoodDiary> UpdateFoodDiaryAsync(FoodDiary foodDiary);
    public Task DeleteFoodDiaryAsync(FoodDiary foodDiary);
}