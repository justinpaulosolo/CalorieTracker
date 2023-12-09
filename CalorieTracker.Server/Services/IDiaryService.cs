using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Services;

public interface IDiaryService
{
    public Task<int?> GetDiaryIdByDateAsync(DateTime date, string userId);
}