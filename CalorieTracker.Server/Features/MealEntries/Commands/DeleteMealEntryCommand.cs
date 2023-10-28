﻿using CalorieTracker.Server.Common;
using MediatR;

namespace CalorieTracker.Server.Features.MealEntries.Commands;

public sealed class DeleteMealEntryCommand : IRequest<OperationResult<bool>>
{
    public int Id { get; set; }
}