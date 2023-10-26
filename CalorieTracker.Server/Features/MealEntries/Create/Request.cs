using System.ComponentModel.DataAnnotations;

namespace CalorieTracker.Server.Features.MealEntries.Create;

public record Request
{
    [Required]
    public string UserId { get; set; } = null!;
    [Required]
    public string MealType { get; set; } = null!;
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public int Proteins { get; set; }
    [Required]
    public int Carbs { get; set; }
    [Required]
    public int Fats { get; set; }
    [Required]
    public int Calories { get; set; }
    [Required]
    public int Quantity { get; set; }
}