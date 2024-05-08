﻿// <auto-generated />
using System;
using CalorieTracker.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CalorieTracker.Server.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("CalorieTracker.Server.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.Diary", b =>
                {
                    b.Property<int>("DiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DiaryId");

                    b.HasIndex("UserId");

                    b.ToTable("Diaries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.Exercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ExerciseId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("Exercise");

                    b.HasData(
                        new
                        {
                            ExerciseId = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(600),
                            ExerciseTypeId = 1,
                            Name = "Running",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(600)
                        },
                        new
                        {
                            ExerciseId = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(600),
                            ExerciseTypeId = 1,
                            Name = "Cycling",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610)
                        },
                        new
                        {
                            ExerciseId = 3,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610),
                            ExerciseTypeId = 1,
                            Name = "Swimming",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610)
                        },
                        new
                        {
                            ExerciseId = 4,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610),
                            ExerciseTypeId = 1,
                            Name = "Walking",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(610)
                        },
                        new
                        {
                            ExerciseId = 5,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620),
                            ExerciseTypeId = 2,
                            Name = "Weightlifting",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620)
                        },
                        new
                        {
                            ExerciseId = 6,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620),
                            ExerciseTypeId = 2,
                            Name = "Bodyweight",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620)
                        },
                        new
                        {
                            ExerciseId = 7,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620),
                            ExerciseTypeId = 2,
                            Name = "Yoga",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(620)
                        });
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ExerciseDiary", b =>
                {
                    b.Property<int>("ExerciseDiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiaryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExerciseDiaryId");

                    b.HasIndex("DiaryId");

                    b.ToTable("ExerciseDiaries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ExerciseDiaryEntry", b =>
                {
                    b.Property<int>("ExerciseDiaryEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseDiaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ExerciseDiaryEntryId");

                    b.HasIndex("ExerciseDiaryId");

                    b.HasIndex("ExerciseTypeId");

                    b.ToTable("ExerciseDiaryEntries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ExerciseType", b =>
                {
                    b.Property<int>("ExerciseTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("ExerciseTypeId");

                    b.ToTable("ExerciseTypes");

                    b.HasData(
                        new
                        {
                            ExerciseTypeId = 1,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(520),
                            Name = "Cardio",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(570)
                        },
                        new
                        {
                            ExerciseTypeId = 2,
                            CreatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(580),
                            Name = "Strength",
                            UpdatedAt = new DateTime(2024, 5, 8, 13, 32, 33, 366, DateTimeKind.Local).AddTicks(580)
                        });
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.Food", b =>
                {
                    b.Property<int>("FoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Calories")
                        .HasColumnType("REAL");

                    b.Property<double>("Carbs")
                        .HasColumnType("REAL");

                    b.Property<double>("Fat")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Protein")
                        .HasColumnType("REAL");

                    b.HasKey("FoodId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.FoodDiary", b =>
                {
                    b.Property<int>("FoodDiaryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DiaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MealTypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FoodDiaryId");

                    b.HasIndex("DiaryId");

                    b.HasIndex("MealTypeId");

                    b.ToTable("FoodDiaries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.FoodDiaryEntry", b =>
                {
                    b.Property<int>("FoodDiaryEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodDiaryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FoodId")
                        .HasColumnType("INTEGER");

                    b.HasKey("FoodDiaryEntryId");

                    b.HasIndex("FoodDiaryId");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodDiaryEntries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.MealType", b =>
                {
                    b.Property<int>("MealTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MealTypeId");

                    b.ToTable("MealTypes");

                    b.HasData(
                        new
                        {
                            MealTypeId = 1,
                            Name = "Breakfast"
                        },
                        new
                        {
                            MealTypeId = 2,
                            Name = "Lunch"
                        },
                        new
                        {
                            MealTypeId = 3,
                            Name = "Dinner"
                        },
                        new
                        {
                            MealTypeId = 4,
                            Name = "Snacks"
                        });
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.NutritionGoal", b =>
                {
                    b.Property<int>("NutritionGoalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Calories")
                        .HasColumnType("REAL");

                    b.Property<double>("Carbs")
                        .HasColumnType("REAL");

                    b.Property<double>("Fat")
                        .HasColumnType("REAL");

                    b.Property<double>("Protein")
                        .HasColumnType("REAL");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("NutritionGoalId");

                    b.HasIndex("UserId");

                    b.ToTable("NutritionGoals");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.SavedExercise", b =>
                {
                    b.Property<int>("SavedExerciseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ExerciseTypeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SavedExerciseId");

                    b.HasIndex("UserId");

                    b.ToTable("SavedExercises");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.SavedFood", b =>
                {
                    b.Property<int>("SavedFoodId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Calories")
                        .HasColumnType("REAL");

                    b.Property<double>("Carbs")
                        .HasColumnType("REAL");

                    b.Property<double>("Fat")
                        .HasColumnType("REAL");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Protein")
                        .HasColumnType("REAL");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SavedFoodId");

                    b.HasIndex("UserId");

                    b.ToTable("SavedFoods");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.Diary", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", "User")
                        .WithMany("Diaries")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.Exercise", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ExerciseDiary", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.Diary", "Diary")
                        .WithMany("ExerciseDiaries")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ExerciseDiaryEntry", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ExerciseDiary", "ExerciseDiary")
                        .WithMany("ExerciseDiaryEntries")
                        .HasForeignKey("ExerciseDiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalorieTracker.Server.Entities.ExerciseType", "ExerciseType")
                        .WithMany()
                        .HasForeignKey("ExerciseTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseDiary");

                    b.Navigation("ExerciseType");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.FoodDiary", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.Diary", "Diary")
                        .WithMany("FoodDiaries")
                        .HasForeignKey("DiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalorieTracker.Server.Entities.MealType", "MealType")
                        .WithMany()
                        .HasForeignKey("MealTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diary");

                    b.Navigation("MealType");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.FoodDiaryEntry", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.FoodDiary", "FoodDiary")
                        .WithMany("FoodDiaryEntries")
                        .HasForeignKey("FoodDiaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalorieTracker.Server.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("FoodDiary");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.NutritionGoal", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.SavedExercise", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.SavedFood", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", "User")
                        .WithMany("SavedFoods")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CalorieTracker.Server.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ApplicationUser", b =>
                {
                    b.Navigation("Diaries");

                    b.Navigation("SavedFoods");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.Diary", b =>
                {
                    b.Navigation("ExerciseDiaries");

                    b.Navigation("FoodDiaries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.ExerciseDiary", b =>
                {
                    b.Navigation("ExerciseDiaryEntries");
                });

            modelBuilder.Entity("CalorieTracker.Server.Entities.FoodDiary", b =>
                {
                    b.Navigation("FoodDiaryEntries");
                });
#pragma warning restore 612, 618
        }
    }
}
