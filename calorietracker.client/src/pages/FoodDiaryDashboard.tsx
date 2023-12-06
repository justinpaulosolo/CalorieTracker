import NutritionInfoCard from "@/components/nutrition-info-card.tsx";
import { useState } from "react";
import { DatePickerDemo } from "@/components/date-picker.tsx";
import RecentFoodEntriesCard from "@/components/recent-food-entries-card.tsx";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card.tsx";

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
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-7">
        <Card className="col-span-4">
          <CardHeader>
            <CardTitle>Test Card</CardTitle>
          </CardHeader>
          <CardContent>
            <h1>Place Holder</h1>
          </CardContent>
        </Card>
        <RecentFoodEntriesCard date={date} />
      </div>
    </div>
  );
}

export default FoodDiaryDashboard;
