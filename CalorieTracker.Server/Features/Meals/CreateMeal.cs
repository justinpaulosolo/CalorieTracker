using System.Security.Claims;
using CalorieTracker.Server.Contracts;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;

namespace CalorieTracker.Server.Features.Meals;

public static class CreateMeal
{
    public sealed class CreateMealCommand : IRequest<int>
    {
        public CreateMealCommand(string name, string userId, DateTime date)
        {
            Name = name;
            UserId = userId;
            Date = date;
        }
        public string Name { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<CreateMealCommand, int>
    {
        public async Task<int> Handle(CreateMealCommand request, CancellationToken cancellationToken)
        {
            var meal = new Meal()
            {
                MealType = request.Name,
                UserId = request.UserId
            };
            
            dbContext.Meals.Add(meal);
            await dbContext.SaveChangesAsync(cancellationToken);
            return meal.MealId;
        }
    }

    public static void CreateMealEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/meals", async (CreateMealRequest request, ISender sender) =>
        {
            var mealId = await sender.Send(request);
            return Results.Ok(mealId);
        }).WithTags("Meals").RequireAuthorization();
    }
    
}