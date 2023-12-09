using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Services;

public class DiaryService(ApplicationDbContext dbContext) : IDiaryService
{
    public async Task<int?> GetDiaryIdByDateAsync(DateTime date, string userId)
    {
        return await dbContext.Diaries
            .Where(d => d.UserId == userId && d.Date.Date == date.Date)
            .Select(d => d.DiaryId)
            .FirstOrDefaultAsync();
    }
}