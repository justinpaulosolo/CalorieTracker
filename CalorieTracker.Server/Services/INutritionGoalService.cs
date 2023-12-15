using CalorieTracker.Server.Models.NutritionGoal;

namespace CalorieTracker.Server.Services;

public interface INutritionGoalService
{
    public Task<int> CreateNutritionGoalAsync(CreateNutritionGoalDto createNutritionGoalDto, string userId);
    public Task<NutritionGoalDto?> GetNutritionGoalAsync(string userId);
    public Task<NutritionGoalDto> UpdateNutritionGoalAsync(UpdateNutritionGoalDto updateNutritionGoalDto);
}