﻿namespace CalorieTracker.Server.Features.Foods;

public class Food
{
    public int FoodId { get; set; }
    public string Name { get; set; } = default!;
    public int Proteins { get; set; }
    public int Carbs { get; set; }
    public int Fats { get; set; }
    public int Calories { get; set; }
}