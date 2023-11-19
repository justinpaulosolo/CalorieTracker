namespace CalorieTracker.Server.Features.Meals.Contracts;

public class GetMealEntryByIdResponse
{
    public int FoodMealEntryId { get; set; }

    public string MealType { get; set; } = default!;

    public string FoodName { get; set; } = default!;

    public int Proteins { get; set; }

    public int Carbs { get; set; }

    public int Fats { get; set; }

    public int Calories { get; set; }
}