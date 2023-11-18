using CalorieTracker.Server.Common;
using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.Meals.Commands;

public static class DeleteMealEntryEndpoint
{
    public static void MapDeleteMealEntryEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapDelete("api/meal-entries/{id}", async (int id, ISender sender) =>
        {
            var result = await sender.Send(new DeleteMealEntryCommand { Id = id });
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Meal Entries").RequireAuthorization();
    }
}

public sealed class DeleteMealEntryCommand : IRequest<OperationResult<bool>>
{
    public int Id { get; set; }
}

public class DeleteMealEntryHandler
    (ApplicationDbContext dbContext) : IRequestHandler<DeleteMealEntryCommand, OperationResult<bool>>
{
    public async Task<OperationResult<bool>> Handle(DeleteMealEntryCommand command, CancellationToken cancellationToken)
    {
        var foodEntry = await dbContext.FoodEntries
            .Include(fe => fe.Food)
            .FirstOrDefaultAsync(fe => fe.FoodEntryId == command.Id, cancellationToken);

        if (foodEntry == null)
            return new OperationResult<bool>
            {
                Errors = new List<string> { $"Food entry with id {command.Id} not found." }
            };

        // Check if the Food is being referenced by other FoodEntries
        var isFoodReferencedElsewhere = await dbContext.FoodEntries
            .AnyAsync(fe => fe.FoodId == foodEntry.FoodId && fe.FoodEntryId != command.Id,
                cancellationToken);

        if (!isFoodReferencedElsewhere)
            // If not, delete the Food
            dbContext.Foods.Remove(foodEntry.Food);

        dbContext.FoodEntries.Remove(foodEntry);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new OperationResult<bool> { Result = true };
    }
}