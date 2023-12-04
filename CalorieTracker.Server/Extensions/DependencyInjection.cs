using CalorieTracker.Server.Repository;
using CalorieTracker.Server.Services;

namespace CalorieTracker.Server.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IFoodDiaryEntryService, FoodDiaryEntryService>();
        services.AddTransient<IDiaryService, DiaryService>();
        services.AddTransient<IAccountService, AccountService>();

        services.AddScoped<IMealTypeRepository, MealTypeRepository>();
        services.AddScoped<IDiaryRepository, DiaryRepository>();
        services.AddScoped<IFoodDiaryRepository, FoodDiaryRepository>();
        services.AddScoped<IFoodDiaryEntryRepository, FoodDiaryEntryRepository>();
        services.AddScoped<IFoodRepository, FoodRepository>();

        return services;
    }
}