using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.SavedFood;

namespace CalorieTracker.Server.Services;

public class SavedFoodService(ApplicationDbContext dbContext) : ISavedFoodService
{
    public async Task<int> CreateSavedFoodAsync(CreateSavedFoodDto createSavedFoodDto, string userId)
    {
        var savedFood = new SavedFood
        {
            Name = createSavedFoodDto.Name,
            Calories = createSavedFoodDto.Calories,
            Protein = createSavedFoodDto.Protein,
            Carbs = createSavedFoodDto.Carbs,
            Fat = createSavedFoodDto.Fat,
            UserId = userId
        };
        
        dbContext.SavedFoods.Add(savedFood);
        await dbContext.SaveChangesAsync();
        return savedFood.SavedFoodId;
    }
}