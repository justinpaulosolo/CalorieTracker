using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<FoodEntry> FoodEntries { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
