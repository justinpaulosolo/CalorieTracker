
namespace CalorieTracker.Server.Contracts;

public class CreateMealRequest
{
    public string Name { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}