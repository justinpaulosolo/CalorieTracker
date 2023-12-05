import NutritionInfoCard from "@/components/nutrition-info-card.tsx";
import { useState } from "react";
import { DatePickerDemo } from "@/components/date-picker.tsx";

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
    </div>
  );
}

export default FoodDiaryDashboard;
