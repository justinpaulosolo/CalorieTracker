using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Repository;

public class DiaryRepository : IDiaryRepository
{
    private readonly ApplicationDbContext _dbContext;
    
    public DiaryRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Diary?> GetDiaryByIdAsync(int diaryId)
    {
        return await _dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.DiaryId == diaryId);
    }

    public async Task<Diary?> GetDiaryByDateAsync(DateTime date, string userId)
    {
        return await _dbContext.Diaries
            .Include(d => d.FoodDiaries)
            .ThenInclude(fd => fd.FoodDiaryEntries)
            .ThenInclude(fde => fde.Food)
            .FirstOrDefaultAsync(d => d.Date.Date == date.Date && d.UserId == userId);
    }

    public async Task<Diary> CreateDiaryAsync(Diary diary)
    {
        await _dbContext.Diaries.AddAsync(diary);
        await _dbContext.SaveChangesAsync();
        return diary;
    }

    public async Task<Diary> UpdateDiaryAsync(Diary diary)
    {
        _dbContext.Diaries.Update(diary);
        await _dbContext.SaveChangesAsync();
        return diary;
    }

    public async Task DeleteDiaryAsync(Diary diary)
    {
        _dbContext.Diaries.Remove(diary);
        await _dbContext.SaveChangesAsync();
    }
}