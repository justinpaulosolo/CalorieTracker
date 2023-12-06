import RecentFoodEntry from "@/components/recent-food-entry.tsx";
import { useGetDiaryFoods } from "@/hooks/useGetDiaryFoods.ts";
import { format } from "date-fns";
import { Skeleton } from "@/components/ui/skeleton.tsx";

export default function RecentFoodEntriesCard({ date }: { date: Date }) {
  const { data: Foods, isLoading } = useGetDiaryFoods(
    format(date, "yyyy-MM-dd"),
  );

  return (
    <div className="space-y-4">
      {isLoading ? (
        <div className="flex items-center animate-pulse">
          <div className="space-y-1">
            <Skeleton className="h-4 w-[50px]" />
            <Skeleton className="h-4 w-[200px]" />
          </div>
          <Skeleton className="ml-auto h-4 w-[25px]"></Skeleton>
        </div>
      ) : (
        Foods?.data.map(food => (
          <RecentFoodEntry key={food.foodId} food={food} />
        ))
      )}
    </div>
  );
}
