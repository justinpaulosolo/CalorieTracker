using MediatR;

namespace CalorieTracker.Server.Features.Meals.Queries;

public class GetMealEntriesByDateAndTypeQuery : IRequest<GetMealEntriesByDateAndTypeResponse?>
{
    public string UserId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string MealType { get; set; } = string.Empty;
}