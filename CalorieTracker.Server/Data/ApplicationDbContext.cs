using CalorieTracker.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<MacrosGoal> MacrosGoals { get; set; }
    public DbSet<UserMeal> UserMeals { get; set; }
    public DbSet<FoodItem> FoodItems { get; set; }
    public DbSet<MealFoodEntry> MealFoodEntries { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }
}
