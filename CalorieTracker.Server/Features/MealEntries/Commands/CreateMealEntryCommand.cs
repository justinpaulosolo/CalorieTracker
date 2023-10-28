using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Commands;

public sealed class CreateMealEntryCommand : IRequest<int>
{
    public string UserId { get; set; } = null!;
    public string MealType { get; init; } = null!;
    public DateTime Date { get; init; }
    public string Name { get; init; } = null!;
    public int Proteins { get; init; }
    public int Carbs { get; init; }
    public int Fats { get; init; }
    public int Calories { get; init; }
    public int Quantity { get; init; }
}