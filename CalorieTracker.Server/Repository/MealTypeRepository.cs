using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Repository;

public class MealTypeRepository : IMealTypeRepository
{
    private readonly ApplicationDbContext _applicationDbContext;
    
    public MealTypeRepository(ApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }
    
    public async Task<MealType?> GetMealTypeByNameAsync(string name)
    {
        return await _applicationDbContext.MealTypes.FirstOrDefaultAsync(mt => mt.Name == name);
    }
}