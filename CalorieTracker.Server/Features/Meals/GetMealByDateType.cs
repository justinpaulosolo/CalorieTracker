using System.Security.Claims;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals;

public static class GetMealByDateType
{
    public sealed class Query : IRequest<Meal?>
    {
        public Query(string mealType, DateTime date, string userId)
        {
            MealType = mealType;
            Date = date;
            UserId = userId;
        }
        public string MealType { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
    }

    internal sealed class QueryHandler(ApplicationDbContext dbContext) : IRequestHandler<Query, Meal?>
    {
        public async Task<Meal?> Handle(Query request, CancellationToken cancellationToken)
        {
            var meal = await dbContext.Meals
                .FirstOrDefaultAsync(m => m.UserId == request.UserId && 
                                          m.Date.Date == request.Date.Date && 
                                          m.MealType == request.MealType, 
                    cancellationToken: cancellationToken);

            return meal;
        }
    }
    
    public static void GetMealByDateTypeEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/meal/", async (string meal, DateTime date, ISender sender, ClaimsPrincipal user) =>
        {
            if (user.Identity == null) return Results.Unauthorized();
            
            var userId = user.Identity.Name;
            var mealResult = await sender.Send(new {meal, date, userId});

            return mealResult == null ? Results.NotFound() : Results.Ok(mealResult);
        }).WithTags("Meals").RequireAuthorization();
    }
}