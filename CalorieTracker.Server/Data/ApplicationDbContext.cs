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


    public DbSet<MealType> MealTypes { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    public DbSet<FoodDiary> FoodDiaries { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodDiaryEntry> FoodDiaryEntries { get; set; }
    public DbSet<SavedFoodItem> SavedFoodItems { get; set; }
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<MealType>().HasData(
            new MealType { MealTypeId = 1, Name = "Breakfast" },
            new MealType { MealTypeId = 2, Name = "Lunch" },
            new MealType { MealTypeId = 3, Name = "Dinner" },
            new MealType { MealTypeId = 4, Name = "Snack" }
        );
    }
}
