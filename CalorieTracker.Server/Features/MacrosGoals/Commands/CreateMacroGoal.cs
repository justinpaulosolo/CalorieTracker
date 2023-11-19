using CalorieTracker.Server.Common;
using CalorieTracker.Server.Data;
using CalorieTracker.Server.Entities;
using CalorieTracker.Server.Features.MacrosGoals.Contracts;
using Carter;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CalorieTracker.Server.Features.MacrosGoals.Commands;

public static class CreateMacroGoal
{
    public class Command : IRequest<OperationResult<int>>
    {
        public string UserId { get; set; } = default!;

        public int ProteinGoal { get; set; }

        public int CarbsGoal { get; set; }

        public int FatsGoal { get; set; }

        public int CaloriesGoal { get; set; }
    }

    internal sealed class Handler(ApplicationDbContext dbContext) : IRequestHandler<Command, OperationResult<int>>
    {
        public async Task<OperationResult<int>> Handle(Command request, CancellationToken cancellationToken)
        {
            var exists = await dbContext.MacrosGoals.FirstOrDefaultAsync(x => x.UserId == request.UserId,
                cancellationToken: cancellationToken);

            if (exists != null)
            {
                return new OperationResult<int>
                {
                    Errors = new List<string> { "Macro goal already exists for the user" }
                };
            }

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
    }
}

public class CreateMacroGoalEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/macro-goal", async (CreateMacroGoalRequest request, ISender sender, ClaimsPrincipal user) =>
        {
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var command = new CreateMacroGoal.Command()
            {
                UserId = userId,
                ProteinGoal = request.ProteinGoal,
                CarbsGoal = request.CarbsGoal,
                FatsGoal = request.FatsGoal,
                CaloriesGoal = request.CaloriesGoal,
            };

            var result = await sender.Send(command);

            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Macro Goal").RequireAuthorization();
    }
}