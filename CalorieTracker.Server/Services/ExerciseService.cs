namespace CalorieTracker.Server.Services;

using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.Exercise;
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

    public async Task<int> CreateExerciseType(CreateExerciseTypeDto createExerciseTypeDto)
    {
        var newExerciseType = new ExerciseType
        {
            Name = createExerciseTypeDto.Name,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };

        await dbContext.ExerciseTypes.AddAsync(newExerciseType);

        await dbContext.SaveChangesAsync();

        return newExerciseType.ExerciseTypeId;
    }

    public async Task<bool> DeleteExerciseTypeById(int id)
    {
        var exerciseType = await dbContext.ExerciseTypes
            .Where(e => e.ExerciseTypeId == id)
            .FirstOrDefaultAsync();
        
        if (exerciseType == null)
        {
            return false;
        }

        dbContext.ExerciseTypes.Remove(exerciseType);
        var result = await dbContext.SaveChangesAsync();

        return result > 0;
    }
}
