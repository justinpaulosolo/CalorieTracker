using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.ExerciseDiary;

namespace CalorieTracker.Server.Services;

public class ExerciseDiaryService(ApplicationDbContext dbContext) : IExerciseDiaryService
{
    public Task<int> CreateExerciseDiary(CreateExerciseDiaryDto createExerciseDiaryDto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteExerciseDiaryById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<ExerciseDiary>> GetAllExerciseDiary()
    {
        throw new NotImplementedException();
    }

    public Task<int?> GetExerciseDiaryById(int id)
    {
        throw new NotImplementedException();
    }
}
