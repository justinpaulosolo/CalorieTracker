﻿using MediatR;

namespace CalorieTracker.Server.Features.Account.Commands;

public static class CreateAccountEndpoints
{
    public static void CreateAccountEndpoint(this IEndpointRouteBuilder app)
    {
        app.MapPost("api/account/register", async (CreateAccountCommand command, ISender sender) =>
        {
            var result = await sender.Send(command);
            return !result.IsSuccessful ? Results.BadRequest(result.Errors) : Results.Ok(result.Result);
        }).WithTags("Account");
    }
}