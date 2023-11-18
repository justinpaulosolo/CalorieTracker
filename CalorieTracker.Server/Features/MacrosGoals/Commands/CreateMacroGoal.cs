using CalorieTracker.Server.Common;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.MacrosGoals.Commands;

public static class CreateMacroGoalEndpoint
{
    public static void MapCreateMacroGoalEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/macro-goal", async (CreateMacroGoalCommand command, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;
            command.UserId = userId;
            var result = await sender.Send(command);
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Macro Goal").RequireAuthorization();
    }
}

    public class CreateMacroGoalCommand : IRequest<OperationResult<int>>
{
    public int Id { get; set; }
    public string UserId { get; set; } = default!;
    public int ProteinGoal { get; set; }
    public int CarbsGoal { get; set; }
    public int FatsGoal { get; set; }
    public int CaloriesGoal { get; set; }
}

public class CreateMacroGoalHandler(ApplicationDbContext dbContext) : IRequestHandler<CreateMacroGoalCommand, OperationResult<int>>
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
