using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.FoodDiaryEntry;
using CalorieTracker.Server.Repository;

namespace CalorieTracker.Server.Services;

public class FoodDiaryEntryService : IFoodDiaryEntryService
{
    private readonly IFoodDiaryEntryRepository _foodDiaryEntryRepository;
    private readonly IFoodDiaryRepository _foodDiaryRepository;
    private readonly IDiaryRepository _diaryRepository;
    private readonly IFoodRepository _foodRepository;
    private readonly IMealTypeRepository _mealTypeRepository;

    public FoodDiaryEntryService(IFoodDiaryEntryRepository foodDiaryEntryRepository,
        IFoodDiaryRepository foodDiaryRepository,
        IDiaryRepository diaryRepository,
        IFoodRepository foodRepository,
        IMealTypeRepository mealTypeRepository)
    {
        _foodDiaryEntryRepository = foodDiaryEntryRepository;
        _foodDiaryRepository = foodDiaryRepository;
        _diaryRepository = diaryRepository;
        _foodRepository = foodRepository;
        _mealTypeRepository = mealTypeRepository;
    }

    public async Task<int> CreateFoodDiaryEntryAsync(CreateFoodDiaryEntryDto createFoodDiaryEntryDto, DateTime date,
        string meal, string userId)
    {
        var diary = await _diaryRepository.GetDiaryByDateAsync(date, userId);

        if (diary == null)
        {
            diary = new Diary
            {
                UserId = userId,
                Date = createFoodDiaryEntryDto.Date,
                FoodDiaries = new List<FoodDiary>()
            };
            await _diaryRepository.CreateDiaryAsync(diary);
        }
        
        var mealType = await _mealTypeRepository.GetMealTypeByNameAsync(meal);
        
        if (mealType == null)
        {
            throw new ArgumentException($"Invalid meal type: {meal}.");
        }
        
        var foodDiary = await _foodDiaryRepository.GetFoodDiaryByDateAndMealTypeAsync(createFoodDiaryEntryDto.Date,
            mealType.MealTypeId,
            diary.UserId);
        
        if (foodDiary == null)
        {
            foodDiary = await _foodDiaryRepository.CreateFoodDiaryAsync(new FoodDiary
            {
                DiaryId = diary.DiaryId,
                MealTypeId = createFoodDiaryEntryDto.MealTypeId,
                FoodDiaryEntries = new List<FoodDiaryEntry>()
            });
        }

        var food = await _foodRepository.GetFoodByNameAndNutrientsAsync(
            createFoodDiaryEntryDto.FoodName,
            createFoodDiaryEntryDto.Calories,
            createFoodDiaryEntryDto.Protein,
            createFoodDiaryEntryDto.Carbs,
            createFoodDiaryEntryDto.Fat
        );

        if (food == null)
        {
            food = new Food()
            {
                Name = createFoodDiaryEntryDto.FoodName,
                Calories = createFoodDiaryEntryDto.Calories,
                Protein = createFoodDiaryEntryDto.Protein,
                Fat = createFoodDiaryEntryDto.Fat,
                Carbs = createFoodDiaryEntryDto.Carbs
            };
            
            await _foodRepository.CreateFoodAsync(food);
        }

        var foodDiaryEntryEntity = await _foodDiaryEntryRepository.CreateFoodDiaryEntryAsync(new FoodDiaryEntry
        {
            FoodId = food.FoodId,
            FoodDiaryId = foodDiary.FoodDiaryId,
        });

        return foodDiaryEntryEntity.FoodDiaryEntryId;
    }
}