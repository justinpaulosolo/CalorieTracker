import { useGetFoodDiaryByDate } from "@/utils/services/diary-services.ts";
import FoodDiaryTable from "../components/food-diary/food-diary-table.tsx";
import FoodDiaryTableSkeleton from "../components/food-diary/food-diary-table-skeleton.tsx";
import { DatePickerDemo } from "@/components/date-picker.tsx";
import { useState } from "react";
import { format } from "date-fns";
import { FoodDiary } from "@/utils/types.ts";

export default function DetailedFoodDiaryPage() {
  const [date, setDate] = useState(new Date());
  const { breakfast, lunch, dinner, snacks, isLoading } = useGetFoodDiaryByDate(
    format(date, "yyyy-MM-dd"),
  ) as {
    breakfast?: FoodDiary;
    lunch?: FoodDiary;
    dinner?: FoodDiary;
    snacks?: FoodDiary;
    isLoading: boolean;
  };

  const meals = [
    { title: "Breakfast", data: breakfast },
    { title: "Lunch", data: lunch },
    { title: "Dinner", data: dinner },
    { title: "Snacks", data: snacks },
  ];

  return (
    <div className="flex flex-col space-y-4">
      <div className="flex justify-between">
        <h1 className="font-bold text-2xl">Food Diary Entries</h1>
        <DatePickerDemo date={date} setDate={setDate} />
      </div>
      {meals.map(meal =>
        isLoading ? (
          <FoodDiaryTableSkeleton key={meal.title} />
        ) : (
          <FoodDiaryTable
            key={meal.title}
            title={meal.title}
            data={meal.data}
            date={format(date, "yyyy-MM-dd")}
          />
        ),
      )}
    </div>
  );
}
