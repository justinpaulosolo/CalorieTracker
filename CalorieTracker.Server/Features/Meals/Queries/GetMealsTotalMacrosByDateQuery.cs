using MediatR;

namespace CalorieTracker.Server.Features.Meals.Queries;

public sealed class GetMealsTotalMacrosByDateQuery : IRequest<GetMealsTotalMacrosByDateResponse>
{
    public DateTime Date { get; set; }
    public string UserId { get; set; } = string.Empty;
}