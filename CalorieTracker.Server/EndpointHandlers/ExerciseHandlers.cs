using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.Exercise;
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

    public static async Task<Results<Ok<int>, NotFound<string>>> CreateExerciseType(
        CreateExerciseTypeDto createExerciseTypeDto,
        IExerciseService exerciseService)
    {
        try
        {
            var exerciseTypeId = await exerciseService.CreateExerciseType(createExerciseTypeDto);
            return TypedResults.Ok(exerciseTypeId);
        }
        catch (Exception ex)
        {
            return TypedResults.NotFound(ex.Message);
        }
    }

    public static async Task<Results<NoContent, NotFound>> DeleteExerciseTypeById(
        int exerciseTypeId,
        IExerciseService exerciseService)
    {
        var isDeleted = await exerciseService.DeleteExerciseTypeById(exerciseTypeId);
        if (isDeleted)
        {
            return TypedResults.NoContent();
        }
        return TypedResults.NotFound();
    }

}

