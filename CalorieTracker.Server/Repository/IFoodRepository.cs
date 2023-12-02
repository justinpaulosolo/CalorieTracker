using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Repository;

public interface IFoodRepository
{
    public Task<Food?> GetFoodByIdAsync(int foodId);
    public Task<Food?> GetFoodByNameAsync(string name);
    public Task<Food?> GetFoodByNameAndNutrientsAsync(string name, string calories, string protein, string carbs, string fat);
    public Task<Food> CreateFoodAsync(Food food);
    public Task<Food> UpdateFoodAsync(Food food);
    public Task DeleteFoodAsync(Food food);
}