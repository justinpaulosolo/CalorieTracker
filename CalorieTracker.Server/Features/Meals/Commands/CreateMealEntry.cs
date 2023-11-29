using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Meals.Contracts;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Commands;

public static class CreateMealEntry
{
    public sealed class Command : IRequest<int>
    {
        public string UserId { get; set; } = default!;

        public string MealType { get; init; } = default!;

        public DateTime Date { get; init; }

        public string FoodName { get; init; } = default!;

        public int Proteins { get; init; }

        public int Carbs { get; init; }

        public int Fats { get; init; }

        public int Calories { get; init; }

        public int Quantity { get; init; }
    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<Command, int>
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
                f.Name == command.FoodName && f.Protein == command.Proteins && f.Carbohydrates == command.Carbs &&
                f.Fat == command.Fats && f.Calories == command.Calories, cancellationToken: cancellationToken);

            if (existingFood != null)
            {
                return existingFood;
            }

            var food = new FoodItem
            {
                Name = command.FoodName,
                Protein = command.Proteins,
                Carbohydrates = command.Carbs,
                Fat = command.Fats,
                Calories = command.Calories
            };

            dbContext.FoodItems.Add(food);
            await dbContext.SaveChangesAsync(cancellationToken);

            return food;
        }
    }
}

public class CreateMealEntryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/meals", async (CreateMealEntryRequest request, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var command = new CreateMealEntry.Command()
            {
                UserId = userId,
                MealType = request.MealType,
                Date = request.Date,
                FoodName = request.FoodName,
                Proteins = request.Proteins,
                Carbs = request.Carbohydrates,
                Fats = request.Fats,
                Calories = request.Calories,
                Quantity = request.Quantity,
            };

            var foodEntryId = await sender.Send(command);

            return Results.Ok(foodEntryId);
        }).WithTags("Meals").RequireAuthorization();
    }
}