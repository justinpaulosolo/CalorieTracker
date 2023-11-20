using CalorieTracker.Server.Data;
using CalorieTracker.Server.Features.MacrosGoals.Contracts;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.MacrosGoals.Queries;

public static class GetMacroGoal
{
    public class Query : IRequest<GetMacroGoalResponse?>
    {
        public string UserId { get; set; } = default!;
    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<Query, GetMacroGoalResponse?>
    {
        public async Task<GetMacroGoalResponse?> Handle(Query request, CancellationToken cancellationToken)
        {
            var result = await dbContext.MacrosGoals.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);

            if (result == null)
            {
                return null;
            }

            var macroGoal = new GetMacroGoalResponse(
                result.Id,
                result.ProteinGoal,
                result.CarbsGoal,
                result.FatsGoal,
                result.CaloriesGoal);

            return macroGoal;
        }
    }
}

public class GetMacroGoalEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("api/macro-goal/", async (ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var query = new GetMacroGoal.Query()
            {
                UserId = userId
            };

            var result = await sender.Send(query);

            return Results.Ok(result);
        }).WithTags("Macro Goal").RequireAuthorization();
    }
}