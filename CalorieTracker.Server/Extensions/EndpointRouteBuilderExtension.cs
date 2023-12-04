﻿using CalorieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Extensions;

public static class EndpointRouteBuilderExtension
{
    public static RouteGroupBuilder RegisterAccountEndpoints(this IEndpointRouteBuilder builder)
    {
        var accountEndpoints = builder.MapGroup("/api/account");
        accountEndpoints.WithTags("Account");
        accountEndpoints.WithOpenApi();

        accountEndpoints.MapPost("/register", AccountHandlers.RegisterAsync)
            .WithSummary("Register a new user")
            .WithDescription("Registers a new user in the system");

        accountEndpoints.MapPost("/login", AccountHandlers.LoginAsync)
            .WithSummary("Login a user")
            .WithDescription("Logs in a user in the system");
        
        accountEndpoints.MapPost("/logout", AccountHandlers.LogoutAsync)
            .RequireAuthorization()
            .WithSummary("Logout a user")
            .WithDescription("Logs out a user in the system");

        accountEndpoints.MapGet("/user", AccountHandlers.GetUserDetails)
            .RequireAuthorization()
            .WithSummary("Get user details")
            .WithDescription("Gets the details of the current user");

        return accountEndpoints;
    }

    public static RouteGroupBuilder RegisterDiaryEndpoints(this IEndpointRouteBuilder builder)
    {
        var diaryEndpoints = builder.MapGroup("/api/diary");
        diaryEndpoints.WithTags("Diary");
        diaryEndpoints.WithOpenApi();
        diaryEndpoints.RequireAuthorization();
        
        diaryEndpoints.MapGet("/{date:datetime}/food", DiaryHandlers.GetFoodDiaryByDateAsync)
            .WithSummary("Get a diary entry by date")
            .WithDescription("Retrieves a diary entry for the current user by date");
        
        diaryEndpoints.MapPost("/{date:datetime}/food/{meal}", FoodDiaryEntryHandlers.CreateFoodDiaryEntryAsync)
            .WithSummary("Create a food diary entry")
            .WithDescription("Creates a food diary entry for the current user");

        return diaryEndpoints;
    }

    public static RouteGroupBuilder RegisterFoodDiaryEntryEndpoints(this IEndpointRouteBuilder builder)
    {
        var foodDiaryEntryEndpoints = builder.MapGroup("/api/food-diary-entry");
        foodDiaryEntryEndpoints.WithTags("FoodDiaryEntry");
        foodDiaryEntryEndpoints.WithOpenApi();
        foodDiaryEntryEndpoints.RequireAuthorization();
        
        foodDiaryEntryEndpoints.MapDelete("/{foodDiaryEntryId:int}", FoodDiaryEntryHandlers.DeleteFoodDiaryEntryAsyncV2)
            .WithSummary("Delete a food diary entry")
            .WithDescription("Deletes a food diary entry for the current user by ID");
        
        return foodDiaryEntryEndpoints;
    }

}
