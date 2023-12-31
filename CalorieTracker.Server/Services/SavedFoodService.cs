using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Models.SavedFood;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<SavedFoodDto>> GetSavedFoodsAsync(string userId)
    {
        return await dbContext.SavedFoods
            .Where(savedFood => savedFood.UserId == userId)
            .Select(savedFood => new SavedFoodDto
            {
                SavedFoodId = savedFood.SavedFoodId,
                Name = savedFood.Name,
                Calories = savedFood.Calories,
                Protein = savedFood.Protein,
                Carbs = savedFood.Carbs,
                Fat = savedFood.Fat
            })
            .ToListAsync();
    }

    public async Task<SavedFood?> GetSavedFoodByIdAsync(int savedFoodId, string userId)
    {
        return await dbContext.SavedFoods
            .Where(savedFood => savedFood.SavedFoodId == savedFoodId && savedFood.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<bool> DeleteSavedFoodAsync(int savedFoodId, string userId)
    {
        var savedFood = await dbContext.SavedFoods
            .FirstOrDefaultAsync(savedFood => savedFood.SavedFoodId == savedFoodId && savedFood.UserId == userId);
        
        if (savedFood == null)
        {
            return false;
        }
        
        dbContext.SavedFoods.Remove(savedFood);
        await dbContext.SaveChangesAsync();
        return true;
    }
}