using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Commands;

public static class CreateMeal
{
    public static void MapCreateMealEntryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/meals", async (Command command, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            command.UserId = userId;
            var foodEntryId = await sender.Send(command);
        }).WithTags("Meals").RequireAuthorization();
    }

    public sealed class Command : IRequest<int>
    {
        public string UserId { get; set; } = null!;
        public string MealType { get; init; } = null!;
        public DateTime Date { get; init; }
        public string Name { get; init; } = null!;
        public int Proteins { get; init; }
        public int Carbs { get; init; }
        public int Fats { get; init; }
        public int Calories { get; init; }
        public int Quantity { get; init; }
    }

    public class Handler
        (ApplicationDbContext dbContext) : IRequestHandler<Command, int>
    {
        public async Task<int> Handle(Command command, CancellationToken cancellationToken)
        {
            var meal = await GetOrCreateMeal(command, cancellationToken);
            var food = await GetOrCreateFood(command, cancellationToken);

            var foodEntry = new MealFoodEntry
            {
                MealId = meal.Id,
                FoodId = food.Id,
                Quantity = command.Quantity
            };

            dbContext.MealFoodEntries.Add(foodEntry);
            await dbContext.SaveChangesAsync(cancellationToken);

            return foodEntry.Id;
        }

        private async Task<UserMeal> GetOrCreateMeal(Command command, CancellationToken cancellationToken)
        {
            var existingMeal = await dbContext.UserMeals.Where(m =>
                    m.UserId == command.UserId && m.Date.Date == command.Date.Date && m.MealType == command.MealType)
                .FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (existingMeal != null)
            {
                return existingMeal;
            }

            var meal = new UserMeal
            {
                UserId = command.UserId,
                MealType = command.MealType,
                Date = command.Date
            };

            dbContext.UserMeals.Add(meal);
            await dbContext.SaveChangesAsync(cancellationToken);
            return meal;
        }

        private async Task<FoodItem> GetOrCreateFood(Command command, CancellationToken cancellationToken)
        {
            var existingFood = await dbContext.FoodItems.FirstOrDefaultAsync(f =>
                f.Name == command.Name && f.Proteins == command.Proteins && f.Carbs == command.Carbs &&
                f.Fats == command.Fats && f.Calories == command.Calories, cancellationToken: cancellationToken);

            if (existingFood != null)
            {
                return existingFood;
            }

            var food = new FoodItem
            {
                Name = command.Name,
                Proteins = command.Proteins,
                Carbs = command.Carbs,
                Fats = command.Fats,
                Calories = command.Calories
            };

            dbContext.FoodItems.Add(food);
            await dbContext.SaveChangesAsync(cancellationToken);
            return food;
        }
    }
}