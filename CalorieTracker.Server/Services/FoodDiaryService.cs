using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.FoodDiary;
using CalorieTracker.Server.Repository;

namespace CalorieTracker.Server.Services;

public class FoodDiaryService : IFoodDiaryService
{
    private readonly IFoodDiaryRepository _foodDiaryRepository;

    public FoodDiaryService(IFoodDiaryRepository foodDiaryRepository)
    {
        _foodDiaryRepository = foodDiaryRepository;
    }

    public async Task<FoodDiary?> GetFoodDiaryByIdAsync(int foodDiaryEntryId)
    {
        return await _foodDiaryRepository.GetFoodDiaryByIdAsync(foodDiaryEntryId);
    }

    public async Task<FoodDiary> CreateFoodDiaryAsync(CreateFoodDiaryDto foodDiary)
    {
        throw new NotImplementedException();
    }

    public async Task<FoodDiary> UpdateFoodDiaryAsync(UpdateFoodDiaryDto foodDiary)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteFoodDiaryAsync(FoodDiary foodDiary)
    {
        throw new NotImplementedException();
    }
}