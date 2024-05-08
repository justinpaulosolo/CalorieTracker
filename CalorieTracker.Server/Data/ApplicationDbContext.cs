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
    public DbSet<Exercise> Exercises { get; set; }
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
            new ExerciseType
            {
                ExerciseTypeId = 1,
                Name = "Cardio",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new ExerciseType
            {
                ExerciseTypeId = 2,
                Name = "Strength",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        );

        modelBuilder.Entity<Exercise>().HasData(
            new Exercise
            {
                ExerciseId = 1,
                Name = "Running",
                ExerciseTypeId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Exercise
            {
                ExerciseId = 2,
                Name = "Cycling",
                ExerciseTypeId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Exercise
            {
                ExerciseId = 3,
                Name = "Swimming",
                ExerciseTypeId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Exercise
            {
                ExerciseId = 4,
                Name = "Walking",
                ExerciseTypeId = 1,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Exercise
            {
                ExerciseId = 5,
                Name = "Weightlifting",
                ExerciseTypeId = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new Exercise
            {
                ExerciseId = 6,
                Name = "Bodyweight",
                ExerciseTypeId = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            },
            new Exercise
            {
                ExerciseId = 7,
                Name = "Yoga",
                ExerciseTypeId = 2,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            }
        );
    }
}
