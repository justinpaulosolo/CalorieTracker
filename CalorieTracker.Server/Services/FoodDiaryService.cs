using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.FoodDiary;
using CalorieTracker.Server.Repository;

namespace CalorieTracker.Server.Services;

public class FoodDiaryService : IFoodDiaryService
{
    private readonly IFoodDiaryRepository _foodDiaryRepository;
    private readonly IDiaryRepository _diaryRepository;
    private readonly IMealTypeRepository _mealTypeRepository;

    public FoodDiaryService(IFoodDiaryRepository foodDiaryRepository, IDiaryRepository diaryRepository, IMealTypeRepository mealTypeRepository)
    {
        _foodDiaryRepository = foodDiaryRepository;
        _diaryRepository = diaryRepository;
        _mealTypeRepository = mealTypeRepository;
    }

    public async Task<FoodDiary?> GetFoodDiaryByIdAsync(int foodDiaryEntryId)
    {
        return await _foodDiaryRepository.GetFoodDiaryByIdAsync(foodDiaryEntryId);
    }

    public async Task<FoodDiary> CreateFoodDiaryAsync(CreateFoodDiaryDto foodDiaryDto)
    {
        var foodDiary = new FoodDiary
        {
            FoodDiaryId = foodDiaryDto.FoodDiaryId,
            DiaryId = foodDiaryDto.DiaryId,
            MealTypeId = foodDiaryDto.MealTypeId
        };
        return await _foodDiaryRepository.CreateFoodDiaryAsync(foodDiary);
    }

    public Task<FoodDiary> UpdateFoodDiaryAsync(UpdateFoodDiaryDto foodDiary)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFoodDiaryAsync(FoodDiary foodDiary)
    {
        throw new NotImplementedException();
    }
}