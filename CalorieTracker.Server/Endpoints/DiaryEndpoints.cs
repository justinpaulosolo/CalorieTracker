using CalorieTracker.Server.EndpointHandlers;

namespace CalorieTracker.Server.Endpoints;

public static class DiaryEndpoints
{
    public static RouteGroupBuilder MapDiaryEndpoints(this IEndpointRouteBuilder builder)
    {
        var diaryEndpoints = builder.MapGroup("/api/diary");
        diaryEndpoints.WithTags("Diary");
        diaryEndpoints.WithOpenApi();
        diaryEndpoints.RequireAuthorization();
        
        diaryEndpoints.MapGet("/{date:datetime}/food", DiaryHandlers.GetFoodDiaryByDateAsync)
            .WithSummary("Get a diary entry by date")
            .WithDescription("Retrieves a diary entry for the current user by date");
        
        diaryEndpoints.MapPost("/food", FoodDiaryEntryHandlers.CreateFoodDiaryEntryAsync)
            .WithSummary("Create a food diary entry")
            .WithDescription("Creates a food diary entry for the current user");
        
        diaryEndpoints.MapDelete("/food/{foodDiaryEntryId:int}", FoodDiaryEntryHandlers.DeleteFoodDiaryEntryAsync)
            .WithSummary("Delete a food diary entry")
            .WithDescription("Deletes a food diary entry for the current user by ID");
        
        diaryEndpoints.MapGet("/foods/{date:datetime}", FoodDiaryEntryHandlers.GetDiaryFoodsEntriesAsync)
            .WithSummary("Get diary foods by date")
            .WithDescription("Retrieves diary foods for the current user by date");

        return diaryEndpoints;
    }
}