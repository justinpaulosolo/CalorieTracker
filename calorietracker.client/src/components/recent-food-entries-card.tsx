import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card.tsx";
import RecentFoodEntry from "@/components/recent-food-entry.tsx";
import { useGetDiaryFoods } from "@/hooks/useGetDiaryFoods.ts";
import { format } from "date-fns";
import { Link } from "react-router-dom";
import { Skeleton } from "@/components/ui/skeleton.tsx";

export default function RecentFoodEntriesCard({ date }: { date: Date }) {
  const { data: Foods, isLoading } = useGetDiaryFoods(
    format(date, "yyyy-MM-dd"),
  );

  return (
    <Card className="col-span-3">
      <CardHeader>
        <CardTitle>Recent Food Entries</CardTitle>
      </CardHeader>
      <CardContent>
        <div className="space-y-8">
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
          <div>
            <Link
              to="/food-diary/detailed"
              className="text-sm underline underline-offset-4"
            >
              View detailed food diary
            </Link>
          </div>
        </div>
      </CardContent>
    </Card>
  );
}
