using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Repository;

public class FoodDiaryEntryRepository : IFoodDiaryEntryRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public FoodDiaryEntryRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<List<Food>> GetFoodsByDiaryIdAsync(int diaryId)
    {
        var foodEntries = await _applicationDbContext.FoodDiaryEntries
            .Where(entry => entry.FoodDiary.DiaryId == diaryId)
            .Select(entry => entry.Food)
            .ToListAsync();

        return foodEntries;
    }

    public async Task<FoodDiaryEntry?> GetFoodDiaryEntryByIdAsync(int foodDiaryEntryId)
    {
        return await _applicationDbContext.FoodDiaryEntries
            .Include(fde => fde.Food)
            .FirstOrDefaultAsync(fde => fde.FoodDiaryEntryId == foodDiaryEntryId);
    }

    public async Task<FoodDiaryEntry?> GetFoodDiaryEntryByFoodDiaryIdAsync(int foodDiaryId)
    {
        return await _applicationDbContext.FoodDiaryEntries
            .Include(fde => fde.Food)
            .FirstOrDefaultAsync(fde => fde.FoodDiaryId == foodDiaryId);
    }

    public async Task<FoodDiaryEntry> CreateFoodDiaryEntryAsync(FoodDiaryEntry foodDiaryEntry)
    {
        await _applicationDbContext.FoodDiaryEntries.AddAsync(foodDiaryEntry);
        await _applicationDbContext.SaveChangesAsync();
        return foodDiaryEntry;
    }

    public async Task<FoodDiaryEntry> UpdateFoodDiaryEntryAsync(FoodDiaryEntry foodDiaryEntry)
    {
        _applicationDbContext.FoodDiaryEntries.Update(foodDiaryEntry);
        await _applicationDbContext.SaveChangesAsync();
        return foodDiaryEntry;
    }

    public async Task<bool> DeleteFoodDiaryEntryAsync(FoodDiaryEntry foodDiaryEntry)
    { 
        _applicationDbContext.FoodDiaryEntries.Remove(foodDiaryEntry); 
        var result = await _applicationDbContext.SaveChangesAsync();
        
        return result > 0;
    }
}