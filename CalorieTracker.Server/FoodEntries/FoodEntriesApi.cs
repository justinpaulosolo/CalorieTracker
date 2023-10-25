using System.Security.Claims;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

namespace CalorieTracker.Server.FoodEntries;

public static class FoodEntriesApi
{
    public static RouteGroupBuilder MapFoodEntries(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("/FoodEntries");
        group.WithTags("FoodEntries");
        group.MapPost("/", async (ApplicationDbContext context, CreateFoodEntryRequest foodEntryRequest) =>
        {
            if (!MiniValidator.TryValidate(foodEntryRequest, out var errors))
            {
                return Results.ValidationProblem(errors);
            }
            
            // Check if the meal exists
            var meal = await context.Meals.FindAsync(foodEntryRequest.MealId);

            if (meal == null)
            {
                return Results.BadRequest("The meal does not exist.");
            }

            var foodEntry = new FoodEntry()
            {
                MealId = foodEntryRequest.MealId,
                FoodId = foodEntryRequest.FoodId,
                Quantity = foodEntryRequest.Quantity
            };

            context.FoodEntries.Add(foodEntry);
            await context.SaveChangesAsync();

            return Results.Created($"/api/foodEntries/{foodEntry.FoodEntryId}", foodEntryRequest);
        });

        group.MapGet("/{mealType}", async (string mealType, ClaimsPrincipal user,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager) =>
        {
            var currentUser = await userManager.GetUserAsync(user);
            if (currentUser == null)
            {
                return Results.Unauthorized();
            }

            var date = DateTime.Now.Date;
            var foodEntries = await context.Meals
                .Where(m => m.UserId == currentUser.Id && m.Date.Date == date && m.MealType == mealType)
                .SelectMany(m => m.FoodEntries)
                .Include(fe => fe.Food)
                .ToListAsync();

            return Results.Ok(foodEntries);
        });
        return group;
    }
}