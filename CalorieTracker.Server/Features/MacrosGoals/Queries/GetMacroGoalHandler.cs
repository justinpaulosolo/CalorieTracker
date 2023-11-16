using CalorieTracker.Server.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MacrosGoals.Queries;

internal sealed class GetMacroGoalHandler(ApplicationDbContext dbContext) : IRequestHandler<GetMacroGoalQuery, GetMacroGoalResponse?>
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
