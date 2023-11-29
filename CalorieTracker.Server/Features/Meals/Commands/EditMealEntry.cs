using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.Meals.Contracts;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.Meals.Commands;

public static class EditMealEntry
{
    public sealed class Command : IRequest<int>
    {
        public int MealFoodEntryId { get; set; }

        public string MealType { get; init; } = default!;

        public DateTime Date { get; init; }

        public string FoodName { get; init; } = default!;

        public int Proteins { get; init; }

        public int Carbohydrates { get; init; }

        public int Fats { get; init; }

        public int Calories { get; init; }

        public string UserId { get; set; } = default!;
    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<Command, int>
    {
        public async Task<int> Handle(Command request, CancellationToken cancellationToken)
        {
            var foodEntry = await dbContext.MealFoodEntries
                .Include(fe => fe.Meal)
                .Include(fe => fe.Food)
                .FirstOrDefaultAsync(fe => fe.Id == request.MealFoodEntryId, cancellationToken: cancellationToken);

            if (foodEntry == null)
            {
                throw new DirectoryNotFoundException(nameof(foodEntry));
            }

            var food = foodEntry.Food;
            food.Name = request.FoodName;
            food.Protein = request.Proteins;
            food.Carbohydrates = request.Carbohydrates;
            food.Fat = request.Fats;
            food.Calories = request.Calories;

            var meal = await dbContext.UserMeals
                .FirstOrDefaultAsync(m => m.UserId == request.UserId
                && m.MealType == request.MealType
                && m.Date.Date == request.Date.Date, cancellationToken: cancellationToken);

            if (meal == null)
            {
                meal = new UserMeal
                {
                    UserId = request.UserId,
                    MealType = request.MealType,
                    Date = request.Date,
                };
                dbContext.UserMeals.Add(meal);
                await dbContext.SaveChangesAsync(cancellationToken);
            }

            foodEntry.MealId = meal.Id;

            await dbContext.SaveChangesAsync(cancellationToken);

            return foodEntry.Id;
        }
    }
}

public class EditMealEntryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("/api/meals/edit/{mealFoodEntryId:int}",
            async (int mealFoodEntryId,
                EditMealEntryRequest request,
                ISender sender,
                ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var command = new EditMealEntry.Command()
            {
                MealFoodEntryId = mealFoodEntryId,
                MealType = request.MealType,
                Date = request.Date,
                FoodName = request.FoodName,
                Proteins = request.Proteins,
                Carbohydrates = request.Carbohydrates,
                Fats = request.Fats,
                Calories = request.Calories,
                UserId = userId
            };

            var result = await sender.Send(command);

            return Results.Ok(result);
        }).WithTags("Meals").RequireAuthorization();
    }
}