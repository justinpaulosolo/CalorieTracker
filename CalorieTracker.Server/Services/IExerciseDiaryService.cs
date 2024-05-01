using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.ExerciseDiary;

namespace CalorieTracker.Server.Services;

public interface IExerciseDiaryService
{
    public Task<int?> GetExerciseDiaryById(int id);
    public Task<List<ExerciseDiary>> GetAllExerciseDiary();
    public Task<int> CreateExerciseDiaryAsync(CreateExerciseDiaryDto createExerciseDiaryDto);
    public Task<bool> DeleteExerciseDiaryById(int id);
}
