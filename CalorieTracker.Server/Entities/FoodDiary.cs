using CalorieTracker.Server.Models;

namespace CalorieTracker.Server.Entities;

public class FoodDiary
{
    public int FoodDiaryId { get; set; }
    public int DiaryId { get; set; }
    public int MealTypeId { get; set; }
    public ICollection<FoodDiaryEntry> FoodDiaryEntries { get; set; } = new List<FoodDiaryEntry>();

    public Diary Diary { get; set; } = null!;

    public NutritionInfo CalculateNutrition()
    {
        var nutrition = new NutritionInfo();

        foreach (var entry in FoodDiaryEntries)
        {
            nutrition.Calories += entry.Food.Calories;
            nutrition.Protein += entry.Food.Protein;
            nutrition.Carbs += entry.Food.Carbs;
            nutrition.Fat += entry.Food.Fat;
        }

        return nutrition;
    }
}
