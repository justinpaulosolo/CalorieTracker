using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Repository;

public class FoodDiaryRepository : IFoodDiaryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public FoodDiaryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<FoodDiary?> GetFoodDiaryByIdAsync(int foodDiaryId)
    {
        return await _applicationDbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.FoodDiaryId == foodDiaryId);
    }

    public async Task<FoodDiary?> GetFoodDiaryByDateAsync(DateTime date, string userId)
    {
        return await _applicationDbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.Diary.Date.Date == date.Date
                                    && fd.Diary.UserId == userId);
    }

    public async Task<FoodDiary?> GetFoodDiaryByDateAndMealTypeAsync(DateTime date, int mealType, string userId)
    {
        return await _applicationDbContext.FoodDiaries
            .Include(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(fd => fd.Diary.Date.Date == date.Date
                                    && fd.MealTypeId == mealType
                                    && fd.Diary.UserId == userId);
    }

    public async Task<FoodDiary> CreateFoodDiaryAsync(FoodDiary foodDiary)
    {
        await _applicationDbContext.FoodDiaries.AddAsync(foodDiary);
        await _applicationDbContext.SaveChangesAsync();
        return foodDiary;
    }

    public async Task<FoodDiary> UpdateFoodDiaryAsync(FoodDiary foodDiary)
    {
        _applicationDbContext.FoodDiaries.Update(foodDiary);
        await _applicationDbContext.SaveChangesAsync();
        return foodDiary;
    }

    public async Task DeleteFoodDiaryAsync(FoodDiary foodDiary)
    {
        _applicationDbContext.FoodDiaries.Remove(foodDiary);
        await _applicationDbContext.SaveChangesAsync();
    }
}