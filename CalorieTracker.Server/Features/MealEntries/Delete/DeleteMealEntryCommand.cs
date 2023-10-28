using CalorieTracker.Server.Common;
using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Delete;

public sealed class DeleteMealEntryCommand : IRequest<CommandResult<bool>>
{
    public int Id { get; set; }
}