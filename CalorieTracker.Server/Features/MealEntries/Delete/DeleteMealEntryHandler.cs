using CalorieTracker.Server.Common;
using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MealEntries.Delete;

internal sealed class DeleteMealEntryHandler
    (ApplicationDbContext dbContext) : IRequestHandler<DeleteMealEntryCommand, CommandResult<bool>>
{
    public async Task<CommandResult<bool>> Handle(DeleteMealEntryCommand command, CancellationToken cancellationToken)
    {
        var foodEntry = await dbContext.FoodEntries
            .Include(fe => fe.Food)
            .FirstOrDefaultAsync(fe => fe.FoodEntryId == command.Id, cancellationToken);

        if (foodEntry == null)
            return new CommandResult<bool>
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

        return new CommandResult<bool> { Result = true };
    }
}