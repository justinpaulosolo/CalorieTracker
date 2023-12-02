using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Repository;

public interface IMealTypeRepository
{
    public Task<MealType?> GetMealTypeByNameAsync(string name);
}