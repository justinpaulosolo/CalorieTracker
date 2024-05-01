using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.Exercise;

namespace CalorieTracker.Server.Services;

public interface IExerciseService
{
    public Task<int?> GetExerciseTypeById(int id);
    public Task<List<ExerciseType>> GetAllExerciseType();
    public Task<int> CreateExerciseType(CreateExerciseTypeDto createExerciseTypeDto);
    public Task<bool> DeleteExerciseTypeById(int id);
}
