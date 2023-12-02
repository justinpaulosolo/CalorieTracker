using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Repository;

public interface IDiaryRepository
{
    public Task<Diary?> GetDiaryByIdAsync(int diaryId);
    public Task<Diary?> GetDiaryByDateAsync(DateTime date, string userId);
    public Task<Diary> CreateDiaryAsync(Diary diary);
    public Task<Diary> UpdateDiaryAsync(Diary diary);
    public Task DeleteDiaryAsync(Diary diary);
}