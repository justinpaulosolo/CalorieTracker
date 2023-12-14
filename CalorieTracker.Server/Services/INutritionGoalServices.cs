using CalorieTracker.Server.Models.NutritionGoal;

namespace CalorieTracker.Server.Services;

public interface INutritionGoalServices
{
    public Task<int> CreateNutritionGoalAsync(CreateNutritionGoalDto createNutritionGoalDto, string userId);
    public Task<NutritionGoalDto?> GetNutritionGoalAsync(string userId);
}