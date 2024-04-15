using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Services;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CalarieTracker.Server.EndpointHandlers;

public static class ExerciseHandlers
{
    public static async Task<Results<Ok<List<ExerciseType>>,
        NotFound<string>>> GetAllExerciseType(
        IExerciseService exerciseService)
    {
        try
        {
            var exerciseType = await exerciseService.GetAllExerciseType();
            return TypedResults.Ok(exerciseType);
        }
        catch (Exception ex)
        {
            return TypedResults.NotFound(ex.Message);
        }
    }
}

