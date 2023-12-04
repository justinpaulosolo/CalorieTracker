using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using Microsoft.AspNetCore.Identity;

namespace CalorieTracker.Server.Extensions;

public static class IdentityConfiguration
{
    public static void ConfigureIdentity(this IServiceCollection services, IWebHostEnvironment environment)
    {
        services.AddIdentity<ApplicationUser, IdentityRole>(options =>
        {
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = false;

            if (environment.IsDevelopment())
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
                options.Password.RequiredUniqueChars = 0;
            };

        }).AddEntityFrameworkStores<ApplicationDbContext>();

        services.ConfigureApplicationCookie(options =>
        {
            options.Events.OnRedirectToLogin = context =>
            {
                context.Response.StatusCode = 401;
                return Task.CompletedTask;
            };
        });
    }
}