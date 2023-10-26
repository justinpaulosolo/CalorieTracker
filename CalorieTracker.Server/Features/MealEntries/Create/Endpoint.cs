using CalorieTracker.Server.Data;
using CalorieTracker.Server.Features.FoodEntries;
using CalorieTracker.Server.Features.Foods;
using CalorieTracker.Server.Features.Meals;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

namespace CalorieTracker.Server.Features.MealEntries.Create;

public static class Endpoint
{
    public static WebApplication MapMealEntriesEndpoint(this WebApplication app)
    {
        app.MapPost("api/meal-entries", HandleAsync).RequireAuthorization();
        return app;
    }

    private static async Task<IResult> HandleAsync(Request request, ApplicationDbContext context)
    {
        if (!MiniValidator.TryValidate(request, out var errors))
            return await Task.FromResult(Results.ValidationProblem(errors));

        int mealId;
        int foodId;

        var existingMeal = await context.Meals.Where(m =>
                m.UserId == request.UserId && m.Date.Date == request.Date.Date && m.MealType == request.MealType)
            .FirstOrDefaultAsync();
        
        if (existingMeal == null)
        {
            var mealRequest = new Meal
            {
                UserId = request.UserId, MealType = request.MealType, Date = request.Date
            };
            
            context.Meals.Add(mealRequest);
            await context.SaveChangesAsync();
            mealId = mealRequest.MealId;
        }
        else
        {
            mealId = existingMeal.MealId;
        }
        
        var existingFood = await context.Foods.FirstOrDefaultAsync(f =>
            f.Name == request.Name && f.Proteins == request.Proteins && f.Carbs == request.Carbs &&
            f.Fats == request.Fats && f.Calories == request.Calories);

        if (existingFood == null)
        {
            var foodRequest = new Food
            {
                Name = request.Name,
                Proteins = request.Proteins,
                Carbs = request.Carbs,
                Fats = request.Fats,
                Calories = request.Calories
            };

            await context.Foods.AddAsync(foodRequest);
            await context.SaveChangesAsync();
            foodId = foodRequest.FoodId;
        }
        else
        {
            foodId = existingFood.FoodId;
        }

        var foodEntry = new FoodEntry
        {
            MealId = mealId, FoodId = foodId, Quantity = request.Quantity
        };

        context.FoodEntries.Add(foodEntry);
        await context.SaveChangesAsync();
        
        var result = await context.FoodEntries
            .Where(fe => fe.FoodEntryId == foodEntry.FoodEntryId)
            .Include(f => f.Food)
            .Select(fe => new 
            {
                MealName = fe.Meal.MealType,
                FoodName = fe.Food.Name,
                fe.Food.Proteins,
                fe.Food.Carbs,
                fe.Food.Fats,
                fe.Food.Calories
            })
            .FirstAsync();
        
        return await Task.FromResult(Results.Ok(result));
    }
}