using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Repository;

namespace CalorieTracker.Server.Services;

public class DiaryService : IDiaryService
{
    private readonly IDiaryRepository _diaryRepository;

    public DiaryService(IDiaryRepository diaryRepository)
    {
        _diaryRepository = diaryRepository;
    }

    public async Task<int?> GetDiaryIdByDateAsync(DateTime date, string userId)
    {
        return await _diaryRepository.GetDiaryIdByDateAsync(date, userId);
    }

    public async Task<Diary?> GetDiaryByUserIdAndDateAsync(DateTime date, string userId)
    {
        return await _diaryRepository.GetDiaryByDateAsync(date, userId);
    }
}