import { FoodDiaryEntry } from "@/utils/types.ts";
import { Link } from "react-router-dom";

export default function RecentFoodEntry({ food }: { food: FoodDiaryEntry; date: Date }) {
  return (
    <Link to={`/food-diary/entry/${food.foodId}/`}>
      <div
        className="flex items-center hover:bg-accent p-3 rounded-xl  transition-colors focus-visible:outline-none focus-visible:ring-1 focus-visible:ring-ring"
        tabIndex={0}
      >
        <div className="space-y-1">
          <p className="text-sm font-medium leading-none">{food.name}</p>
          <p className="text-sm text-muted-foreground">
            Protein: {food.protein}g Carbs: {food.carbs}g Fat: {food.fat}g
          </p>
        </div>
        <div className="ml-auto font-medium">
          {food.calories}
          <span className="text-sm text-muted-foreground">kcal</span>
        </div>
      </div>
    </Link>
  );
}
