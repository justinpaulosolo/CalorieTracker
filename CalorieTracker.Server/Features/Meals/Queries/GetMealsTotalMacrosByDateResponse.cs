namespace CalorieTracker.Server.Features.Meals.Queries;

public class GetMealsTotalMacrosByDateResponse
{
    public DateTime Date { get; set; }
    public long TotalProteins { get; set; }
    public long TotalCarbs { get; set; }
    public long TotalFats { get; set; }
    public long TotalCalories { get; set; }
}