using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Read;

public class GetMealEntriesByDateAndTypeQuery : IRequest<List<GetMealEntriesByDateAndTypeResponse>>
{
    public string UserId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string MealType { get; set; } = string.Empty;
}