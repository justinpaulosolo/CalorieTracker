using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models;
using CalorieTracker.Server.Models.FoodDiary;

namespace CalorieTracker.Server.Services;

public interface IFoodDiaryService
{
    public Task<FoodDiary?> GetFoodDiaryByIdAsync(int foodDiaryId);
    public Task<int?> GetFoodDiaryIdByDateAsync(DateTime date, string userId);
    public Task<NutritionInfo?> GetNutritionInfoAsync(int diaryId);
    public Task<FoodDiary> CreateFoodDiaryAsync(CreateFoodDiaryDto foodDiary);
    public Task<FoodDiary> UpdateFoodDiaryAsync(UpdateFoodDiaryDto foodDiary);
    public Task DeleteFoodDiaryAsync(FoodDiary foodDiary);
}