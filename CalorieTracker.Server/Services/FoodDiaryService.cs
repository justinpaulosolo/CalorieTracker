using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models;
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

    public Task<int?> GetFoodDiaryIdByDateAsync(DateTime date, string userId)
    {
        return _diaryRepository.GetFoodDiaryIdByDateAsync(date, userId);
    }

    public async Task<NutritionInfo?> GetNutritionInfoAsync(int diaryId)
    {
        var foodDiaries = await _foodDiaryRepository.GetFoodDiariesByDiaryId(diaryId);
    
        var nutritionInfo = new NutritionInfo();

        if (foodDiaries.Count == 0) return nutritionInfo;
        foreach (var foodDiary in foodDiaries)
        {
            nutritionInfo.Calories += foodDiary.FoodDiaryEntries.Sum(fde => fde.Food.Calories);
            nutritionInfo.Protein += foodDiary.FoodDiaryEntries.Sum(fde => fde.Food.Protein);
            nutritionInfo.Carbs += foodDiary.FoodDiaryEntries.Sum(fde => fde.Food.Carbs);
            nutritionInfo.Fat += foodDiary.FoodDiaryEntries.Sum(fde => fde.Food.Fat);
        }

        return nutritionInfo;
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