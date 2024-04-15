namespace CalorieTracker.Server.Services;

using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

public class ExerciseService(ApplicationDbContext dbContext) : IExerciseService
{
    public async Task<int?> GetExerciseTypeById(int id)
    {
        return await dbContext.ExerciseTypes
            .Where(e => e.ExerciseTypeId == id)
            .Select(e => e.ExerciseTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<ExerciseType>> GetAllExerciseType()
    {
        return await dbContext.ExerciseTypes.ToListAsync();
    }

    public Task<int> CreateExerciseType(ExerciseType exerciseType)
    {
        throw new NotImplementedException();
    }
}
