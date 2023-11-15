using CalorieTracker.Server.Common;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Server.Features.MacrosGoals.Commands;

internal sealed class CreateMacroGoalHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateMacroGoalCommand, OperationResult<int>>
{
    public async Task<OperationResult<int>> Handle(CreateMacroGoalCommand request, CancellationToken cancellationToken)
    {
        var exists = dbContext.MacrosGoals.FirstOrDefaultAsync(x => x.UserId == request.UserId, cancellationToken: cancellationToken);

        if (exists == null)
        {
            var macroGoal = new MacrosGoal()
            {
                UserId = request.UserId,
                ProteinGoal = request.ProteinGoal,
                CarbsGoal = request.CarbsGoal,
                FatsGoal = request.FatsGoal,
                CaloriesGoal = request.CaloriesGoal,
            };

            await dbContext.MacrosGoals.AddAsync(macroGoal, cancellationToken);
            await dbContext.SaveChangesAsync(cancellationToken);

            return new OperationResult<int> { Result = macroGoal.Id };
        }
        return new OperationResult<int>
        {
            Errors = ["Macro goal already exists for the user"]
        };
    }
}
