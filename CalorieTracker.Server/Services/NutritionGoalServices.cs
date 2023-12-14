using CalorieTracker.Server.Models.NutritionGoal;

namespace CalorieTracker.Server.Services;

public class NutritionGoalServices : INutritionGoalServices
{
    public async Task<int> CreateNutritionGoalAsync(CreateNutritionGoalDto createNutritionGoalDto, string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<NutritionGoalDto?> GetNutritionGoalAsync(string userId)
    {
        throw new NotImplementedException();
    }
}
