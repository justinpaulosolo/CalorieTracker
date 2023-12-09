using CalorieTracker.Server.Services;

namespace CalorieTracker.Server.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IFoodDiaryService, FoodDiaryService>();
        services.AddTransient<IDiaryService, DiaryService>();
        services.AddTransient<IAccountService, AccountService>();

        return services;
    }
}