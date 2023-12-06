import { DiaryFood } from "@/utils/types.ts";

export default function RecentFoodEntry({ food }: { food: DiaryFood }) {
  return (
    <div className="flex items-center">
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
  );
}
