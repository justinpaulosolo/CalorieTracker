using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models;
using CalorieTracker.Server.Models.FoodDiaryEntry;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Services;

public class FoodDiaryService(ApplicationDbContext dbContext) : IFoodDiaryService
{
    public async Task<int> CreateFoodDiaryEntryAsync(CreateFoodDiaryEntryDto createFoodDiaryEntryDto, string userId)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();
        var diary = await dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.Date.Date == createFoodDiaryEntryDto.Date && d.UserId == userId);

        if (diary == null)
        {
            diary = new Diary
            {
                UserId = userId,
                Date = createFoodDiaryEntryDto.Date,
                FoodDiaries = new List<FoodDiary>()
            };
            await dbContext.Diaries.AddAsync(diary);
            await dbContext.SaveChangesAsync();
        }
        
        var mealType = await dbContext.MealTypes.FirstOrDefaultAsync(mt => mt.Name == createFoodDiaryEntryDto.Meal);
        
        
        var foodDiary = await dbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.Diary.Date.Date == createFoodDiaryEntryDto.Date
                                    && fd.MealTypeId == mealType!.MealTypeId
                                    && fd.Diary.UserId == userId);

        if (foodDiary == null)
        {
            foodDiary = new FoodDiary
            {
                DiaryId = diary.DiaryId,
                MealTypeId = mealType!.MealTypeId,
                FoodDiaryEntries = new List<FoodDiaryEntry>()
            };
            await dbContext.FoodDiaries.AddAsync(foodDiary);
            await dbContext.SaveChangesAsync();
        }

        var food = new Food
        {
            Name = createFoodDiaryEntryDto.FoodName,
            Protein = createFoodDiaryEntryDto.Protein,
            Carbs = createFoodDiaryEntryDto.Carbs,
            Fat = createFoodDiaryEntryDto.Fat,
            Calories = createFoodDiaryEntryDto.Calories
        };
        
        await dbContext.Foods.AddAsync(food);
        await dbContext.SaveChangesAsync();
        
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

    public async Task<List<Food>> GetDiaryFoodsByDate(DateTime date, string userId)
    {
        var diary = await dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.Date.Date == date && d.UserId == userId);

        if (diary == null) return new List<Food>();
        var foods = diary.FoodDiaries.SelectMany(fd => fd.FoodDiaryEntries.Select(fde => fde.Food)).ToList();
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
}