using CalorieTracker.Server.Common;
using CalorieTracker.Server.Data;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Commands;

public static class DeleteMealEntry
{
    public class Command : IRequest<OperationResult<bool>>
    {
        public int Id { get; set; }
    }

    internal sealed class Handler
        (ApplicationDbContext dbContext) : IRequestHandler<Command, OperationResult<bool>>
    {
        public async Task<OperationResult<bool>> Handle(Command command, CancellationToken cancellationToken)
        {
            var foodEntry = await dbContext.MealFoodEntries
                .Include(fe => fe.Food)
                .FirstOrDefaultAsync(fe => fe.Id == command.Id, cancellationToken);

            if (foodEntry == null)
                return new OperationResult<bool>
                {
                    Errors = new List<string> { $"Food entry with id {command.Id} not found." }
                };

            // Check if the Food is being referenced by other FoodEntries
            var isFoodReferencedElsewhere = await dbContext.MealFoodEntries
                .AnyAsync(fe => fe.FoodId == foodEntry.FoodId && fe.Id != command.Id,
                    cancellationToken);

            if (!isFoodReferencedElsewhere)
                // If not, delete the Food
                dbContext.FoodItems.Remove(foodEntry.Food);

            dbContext.MealFoodEntries.Remove(foodEntry);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new OperationResult<bool> { Result = true };
        }
    }
}

public class DeleteMealEntryEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/meals/{id:int}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteMealEntry.Command { Id = id });

            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Meals").RequireAuthorization();
    }
}
