using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.NutritionGoal;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Services;

public class NutritionGoalServices(ApplicationDbContext dbContext) : INutritionGoalServices
{
    public async Task<int> CreateNutritionGoalAsync(CreateNutritionGoalDto createNutritionGoalDto, string userId)
    {
        var nutritionGoal = new NutritionGoal
        {
            Calories = createNutritionGoalDto.Calories,
            Protein = createNutritionGoalDto.Protein,
            Carbs = createNutritionGoalDto.Carbs,
            Fat = createNutritionGoalDto.Fat,
            UserId = userId
        };
        
        await dbContext.NutritionGoals.AddAsync(nutritionGoal);
        await dbContext.SaveChangesAsync();
        return nutritionGoal.NutritionGoalId;
    }

    public async Task<NutritionGoalDto?> GetNutritionGoalAsync(string userId)
    {
        var nutritionGoal = await dbContext.NutritionGoals
            .Where(ng => ng.UserId == userId)
            .Select(ng => new NutritionGoalDto
            {
                NutritionGoalId = ng.NutritionGoalId,
                Calories = ng.Calories,
                Protein = ng.Protein,
                Carbs = ng.Carbs,
                Fat = ng.Fat
            })
            .FirstOrDefaultAsync();

        return nutritionGoal;
    }
}
