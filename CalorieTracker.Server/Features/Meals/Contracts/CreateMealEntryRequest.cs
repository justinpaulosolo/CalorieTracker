namespace CalorieTracker.Server.Features.Meals.Contracts;

public class CreateMealEntryRequest
{

    public string MealType { get; init; } = default!;

    public DateTime Date { get; init; }

    public string Name { get; init; } = default!;

    public int Proteins { get; init; }

    public int Carbs { get; init; }

    public int Fats { get; init; }

    public int Calories { get; init; }

    public int Quantity { get; init; }
}
