using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.MacrosGoals.Queries;

public static class GetMacroGoalEndpoint
{
    public static void MapGetMacroGoalEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapGet("api/macro-goal/", async (ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            var query = new GetMacroGoalQuery { UserId = userId };
            var result = await sender.Send(query);
            return Results.Ok(result);
        }).WithTags("Macro Goal").RequireAuthorization();
    }
}

public class GetMacroGoalResponse
{
    public int Id { get; set; }
    public int ProteinGoal { get; set; }
    public int CarbsGoal { get; set; }
    public int FatGoal { get; set; }
    public int CaloriesGoal { get; set; }
}

public class GetMacroGoalQuery : IRequest<GetMacroGoalResponse?>
{
    public string UserId { get; set; } = default!;
}

public class GetMacroGoalHandler(ApplicationDbContext dbContext) : IRequestHandler<GetMacroGoalQuery, GetMacroGoalResponse?>
{
    public async Task<GetMacroGoalResponse?> Handle(GetMacroGoalQuery request, CancellationToken cancellationToken)
    {
        var result = await dbContext.MacrosGoals.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken);

        if (result == null)
        {
            return null;
        }

        var macroGoal = new GetMacroGoalResponse()
        {
            Id = result.Id,
            ProteinGoal = result.ProteinGoal,
            CarbsGoal = result.CarbsGoal,
            FatGoal = result.FatsGoal,
            CaloriesGoal = result.CaloriesGoal
        };

        return macroGoal;
    }
}
