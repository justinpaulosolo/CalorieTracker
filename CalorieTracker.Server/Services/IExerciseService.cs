using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Services;

public interface IExerciseService
{
    public Task<int?> GetExerciseTypeById(int id);
    public Task<List<ExerciseType>> GetAllExerciseType();
    public Task<int> CreateExerciseType(ExerciseType exerciseType);
}
