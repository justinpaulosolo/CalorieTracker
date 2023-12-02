using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Repository;

public class FoodRepository : IFoodRepository
{
    private readonly ApplicationDbContext _applicationDbContext;

    public FoodRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Food?> GetFoodByIdAsync(int foodId)
    {
        return await _applicationDbContext.Foods.FindAsync(foodId);
    }

    public async Task<Food?> GetFoodByNameAsync(string name)
    {
        return await _applicationDbContext.Foods.FirstOrDefaultAsync(f => f.Name == name);
    }

    public async Task<Food> CreateFoodAsync(Food food)
    {
        await _applicationDbContext.Foods.AddAsync(food);
        await _applicationDbContext.SaveChangesAsync();
        return food;
    }

    public async Task<Food> UpdateFoodAsync(Food food)
    {
        _applicationDbContext.Foods.Update(food);
        await _applicationDbContext.SaveChangesAsync();
        return food;
    }

    public async Task DeleteFoodAsync(Food food)
    {
        _applicationDbContext.Foods.Remove(food);
        await _applicationDbContext.SaveChangesAsync();
    }
}