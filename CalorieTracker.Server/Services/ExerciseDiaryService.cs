using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.ExerciseDiary;

namespace CalorieTracker.Server.Services;

public class ExerciseDiaryService(ApplicationDbContext dbContext) : IExerciseDiaryService
{
    public async Task<int> CreateExerciseDiaryAsync(CreateExerciseDiaryDto createExerciseDiaryDto)
    {
        var exerciseDiary = new ExerciseDiary
        {
            DiaryId = createExerciseDiaryDto.DiaryId,
            ExerciseDiaryId = createExerciseDiaryDto.ExerciseTypeId
        };

        dbContext.ExerciseDiaries.Add(exerciseDiary);

        await dbContext.SaveChangesAsync();

        return exerciseDiary.ExerciseDiaryId;
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
