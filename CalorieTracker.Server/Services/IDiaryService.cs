using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Services;

public interface IDiaryService
{
    public Task<Diary?> GetDiaryByUserIdAndDateAsync(string userId, DateTime date);
}