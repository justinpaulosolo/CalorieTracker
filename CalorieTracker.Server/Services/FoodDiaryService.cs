using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models;
using CalorieTracker.Server.Models.Food;
using CalorieTracker.Server.Models.FoodDiaryEntry;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Services;

public class FoodDiaryService(ApplicationDbContext dbContext) : IFoodDiaryService
{
    public async Task<int> CreateFoodDiaryEntryAsync(CreateFoodDiaryEntryDto createFoodDiaryEntryDto, string userId)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        
        var diary = await GetOrCreateDiaryByDate(createFoodDiaryEntryDto.Date, userId);
        
        var mealType = await GetMealByName(createFoodDiaryEntryDto.Meal);
        
        var foodDiary = await GetOrCreateFoodDiary(createFoodDiaryEntryDto.Date, userId, mealType, diary);
        
        var food = await CreateFood(createFoodDiaryEntryDto.FoodName, createFoodDiaryEntryDto.Protein,
            createFoodDiaryEntryDto.Carbs, createFoodDiaryEntryDto.Fat, createFoodDiaryEntryDto.Calories);

        
        var foodDiaryEntry = new FoodDiaryEntry
        {
            FoodDiaryId = foodDiary.FoodDiaryId,
            FoodId = food.FoodId,
        };
        
        await dbContext.FoodDiaryEntries.AddAsync(foodDiaryEntry);
        await dbContext.SaveChangesAsync();
        
        await transaction.CommitAsync();
        
        return foodDiaryEntry.FoodDiaryEntryId;
    }

    public async Task<int> UpdateFoodDiaryEntryAsync(UpdateFoodDiaryEntryDto updateFoodDiaryEntryDto, int foodDiaryEntryId, string userId)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
         
        var diary = await GetOrCreateDiaryByDate(updateFoodDiaryEntryDto.Date, userId);

        var mealType = await GetMealByName(updateFoodDiaryEntryDto.Meal);
        
        var foodDiary = await GetOrCreateFoodDiary(updateFoodDiaryEntryDto.Date, userId, mealType, diary);
        
        var foodDiaryEntry = await dbContext.FoodDiaryEntries
            .Include(fde => fde.Food)
            .FirstAsync(fde => fde.FoodDiaryEntryId == foodDiaryEntryId);

        foodDiaryEntry.FoodDiaryId = foodDiary.FoodDiaryId; 
        
        var food = foodDiaryEntry.Food;
        food.Name = updateFoodDiaryEntryDto.Name;
        food.Protein = updateFoodDiaryEntryDto.Protein;
        food.Carbs = updateFoodDiaryEntryDto.Carbs;
        food.Fat = updateFoodDiaryEntryDto.Fat;
        food.Calories = updateFoodDiaryEntryDto.Calories;
        
        dbContext.Foods.Update(food);
        dbContext.FoodDiaryEntries.Update(foodDiaryEntry);
        await dbContext.SaveChangesAsync();
        
        await transaction.CommitAsync();

        return foodDiaryEntry.FoodDiaryEntryId;
    }

    public async Task<bool> DeleteFoodDiaryEntryByIdAsync(int foodDiaryEntryId, string userId)
    {
        var foodDiaryEntry = await dbContext.FoodDiaryEntries
            .Include(fde => fde.Food)
            .FirstOrDefaultAsync(fde => fde.FoodDiaryEntryId == foodDiaryEntryId);

        if (foodDiaryEntry == null)
        {
            return false;
        }

        dbContext.FoodDiaryEntries.Remove(foodDiaryEntry);
        var result = await dbContext.SaveChangesAsync();

        return result > 0;
    }

    public async Task<Diary?> GetFoodDiaryByDateAsync(DateTime date, string userId)
    {
        return await dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.Date.Date == date.Date && d.UserId == userId);
    }

    public async Task<List<FoodDto>> GetDiaryFoodsByDate(DateTime date, string userId)
    {
        var diary = await dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.Date.Date == date && d.UserId == userId);

        if (diary == null) return [];
        var foods = diary.FoodDiaries.SelectMany(fd => fd.FoodDiaryEntries.Select(fde => new FoodDto()
        {
            Date = diary.Date,
            FoodDiaryEntryId = fde.FoodDiaryEntryId,
            FoodId = fde.Food.FoodId,
            Name = fde.Food.Name,
            Calories = fde.Food.Calories,
            Protein = fde.Food.Protein,
            Carbs = fde.Food.Carbs,
            Fat = fde.Food.Fat
        } )).ToList();
        return foods;
    }

    public async Task<NutritionInfo?> GetNutritionInfoAsync(int diaryId)
    {
        var foodDiaries = await dbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .Where(fd => fd.DiaryId == diaryId)
            .ToListAsync();
        
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

    public async Task<FoodDto> GetFoodDiaryEntryById(int foodDiaryEntryId)
    {
        var foodDiaryEntry = await dbContext.FoodDiaryEntries
            .Include(fde => fde.Food)
            .Include(foodDiaryEntry => foodDiaryEntry.FoodDiary)
            .ThenInclude(foodDiary => foodDiary.Diary).Include(foodDiaryEntry => foodDiaryEntry.FoodDiary)
            .ThenInclude(foodDiary => foodDiary.MealType)
            .FirstOrDefaultAsync(fde => fde.FoodDiaryEntryId == foodDiaryEntryId);

        if (foodDiaryEntry == null) return null!;
        
        var food = foodDiaryEntry.Food;
        var foodDto = new FoodDto
        {
            Date = foodDiaryEntry.FoodDiary.Diary.Date,
            Meal = foodDiaryEntry.FoodDiary.MealType.Name,
            FoodDiaryEntryId = foodDiaryEntry.FoodDiaryEntryId,
            FoodId = food.FoodId,
            Name = food.Name,
            Calories = food.Calories,
            Protein = food.Protein,
            Carbs = food.Carbs,
            Fat = food.Fat
        };

        return foodDto;
    }

    private async Task<MealType> GetMealByName(string name)
    {
        return await dbContext.MealTypes.AsNoTracking().FirstAsync(mt => mt.Name == name);
    }
    
    private async Task<Diary> GetOrCreateDiaryByDate(DateTime date, string userId)
    {
        var diary = await dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.Date.Date == date && d.UserId == userId);

        if (diary != null) return diary;
        
        diary = new Diary
        {
            UserId = userId,
            Date = date,
            FoodDiaries = new List<FoodDiary>()
        };
        await dbContext.Diaries.AddAsync(diary);
        await dbContext.SaveChangesAsync();

        return diary;
    }
    
    private async Task<FoodDiary> GetOrCreateFoodDiary(DateTime  date, string userId,
        MealType mealType, Diary diary)
    {
        var foodDiary = await dbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.Diary.Date.Date == date
                                       && fd.MealTypeId == mealType!.MealTypeId
                                       && fd.Diary.UserId == userId);

        if (foodDiary != null) return foodDiary;
        
        foodDiary = new FoodDiary
        {
            DiaryId = diary.DiaryId,
            MealTypeId = mealType!.MealTypeId,
            FoodDiaryEntries = new List<FoodDiaryEntry>()
        };
        await dbContext.FoodDiaries.AddAsync(foodDiary);
        await dbContext.SaveChangesAsync();

        return foodDiary;
    }

    private async Task<Food> CreateFood(string name, double protein, double carbs, double fat, double calories)
    {
        var food = new Food
        {
            Name = name,
            Protein = protein,
            Carbs = carbs,
            Fat = fat,
            Calories = calories
        };
        
        await dbContext.Foods.AddAsync(food);
        await dbContext.SaveChangesAsync();

        return food;
    }
}