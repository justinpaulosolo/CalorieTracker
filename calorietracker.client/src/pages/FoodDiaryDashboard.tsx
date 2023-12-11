import { useState } from "react";
import { Link } from "react-router-dom";
import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card.tsx";
import NutritionInfoCard from "@/components/nutrition-info-card.tsx";
import RecentFoodEntriesCard from "@/components/recent-food-entries-card.tsx";
import FoodDiaryEntryQuickAddForm from "@/components/food-diary/forms/food-diary-entry-quick-add-form.tsx";

function FoodDiaryDashboard() {
  const [date] = useState(new Date());
  return (
    <div className="flex flex-col space-y-4">
      <div className="flex justify-between">
        <h1 className="font-bold text-2xl">Food Diary Dashboard</h1>
      </div>
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
        <NutritionInfoCard date={date} />
      </div>
      <div className="grid gap-4 grid-cols-6 items-start">
        <Card className="col-span-3">
          <CardHeader>
            <CardTitle>Add Food Diary Entry</CardTitle>
          </CardHeader>
          <CardContent>
            <FoodDiaryEntryQuickAddForm date={date} />
          </CardContent>
        </Card>
        <Card className="col-span-3 p-0">
          <CardHeader>
            <CardTitle>Recent Food Diary Entries</CardTitle>
          </CardHeader>
          <CardContent className="p-3">
            <RecentFoodEntriesCard date={date} />
          </CardContent>
          <CardFooter className="mt-auto">
            <Link
              to="/food-diary/detailed"
              className="text-sm underline underline-offset-4"
            >
              View detailed food diary
            </Link>
          </CardFooter>
        </Card>
      </div>
    </div>
  );
}

export default FoodDiaryDashboard;
