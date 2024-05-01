using CalorieTracker.Server.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public DbSet<MealType> MealTypes { get; set; }
    public DbSet<Diary> Diaries { get; set; }
    public DbSet<FoodDiary> FoodDiaries { get; set; }
    public DbSet<Food> Foods { get; set; }
    public DbSet<FoodDiaryEntry> FoodDiaryEntries { get; set; }
    public DbSet<SavedFood> SavedFoods { get; set; }
    public DbSet<NutritionGoal> NutritionGoals { get; set; }

    // Exercise
    public DbSet<ExerciseType> ExerciseTypes { get; set; }
    public DbSet<SavedExercise> SavedExercises { get; set; }
    public DbSet<ExerciseDiary> ExerciseDiaries { get; set; }
    public DbSet<ExerciseDiaryEntry> ExerciseDiaryEntries { get; set; }
    
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
            new MealType { MealTypeId = 4, Name = "Snacks" }
        );

        modelBuilder.Entity<ExerciseType>().HasData(
            new ExerciseType { ExerciseTypeId = 1, Name = "Running" },
            new ExerciseType { ExerciseTypeId = 2, Name = "Walking" },
            new ExerciseType { ExerciseTypeId = 3, Name = "Cycling" },
            new ExerciseType { ExerciseTypeId = 4, Name = "Swimming" },
            new ExerciseType { ExerciseTypeId = 5, Name = "Weightlifting" },
            new ExerciseType { ExerciseTypeId = 6, Name = "Yoga" },
            new ExerciseType { ExerciseTypeId = 7, Name = "Pilates" },
            new ExerciseType { ExerciseTypeId = 8, Name = "Dancing" },
            new ExerciseType { ExerciseTypeId = 9, Name = "Boxing" }
        );
    }
}
