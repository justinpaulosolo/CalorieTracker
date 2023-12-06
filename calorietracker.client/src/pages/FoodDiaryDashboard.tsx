import NutritionInfoCard from "@/components/nutrition-info-card.tsx";
import { useState } from "react";
import { DatePickerDemo } from "@/components/date-picker.tsx";
import RecentFoodEntriesCard from "@/components/recent-food-entries-card.tsx";
import {
  Card,
  CardContent,
  CardFooter,
  CardHeader,
  CardTitle,
} from "@/components/ui/card.tsx";
import FoodQuickAddForm from "@/components/food-diary/food-quick-add-form.tsx";
import { Link } from "react-router-dom";

function FoodDiaryDashboard() {
  const [date, setDate] = useState(new Date());
  console.log(date);
  return (
    <div className="flex flex-col space-y-4">
      <div className="flex justify-between">
        <h1 className="font-bold text-2xl">Food Diary Dashboard</h1>
        <DatePickerDemo date={date} setDate={setDate} />
      </div>
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-4">
        <NutritionInfoCard date={date} />
      </div>
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7 items-start">
        <Card className="col-span-4">
          <CardHeader>
            <CardTitle>Add Food Diary Entry</CardTitle>
          </CardHeader>
          <CardContent>
            <FoodQuickAddForm date={date} />
          </CardContent>
        </Card>
        <Card className="col-span-3">
          <CardHeader>
            <CardTitle>Recent Food Diary Entries</CardTitle>
          </CardHeader>
          <CardContent className="">
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
