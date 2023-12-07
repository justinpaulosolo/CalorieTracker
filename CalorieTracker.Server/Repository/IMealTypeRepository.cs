using CalorieTracker.Server.Entities;

namespace CalorieTracker.Server.Repository;

public interface IMealTypeRepository
{
    // Todo: This will never be null, so we should use a non-nullable return type
    public Task<MealType?> GetMealTypeByNameAsync(string name);
}