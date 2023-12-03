import { useGetFoodDiaryByDate } from "@/utils/services/diary-services";
import FoodDiaryTable from "./food-diary-table";
import FoodDiaryTableSkeleton from "./food-diary-table-skeleton";
import { DatePickerDemo } from "@/components/date-picker";
import { useState } from "react";
import { format } from "date-fns";
import { FoodDiary } from "@/utils/types.ts";

export default function FoodDiaryPage() {
  const [date, setDate] = useState(new Date());
  const { breakfast, lunch, dinner, snacks, isLoading } = useGetFoodDiaryByDate(
    format(date, "yyyy-MM-dd")
  ) as { breakfast?: FoodDiary; lunch?: FoodDiary; dinner?: FoodDiary; snacks?: FoodDiary; isLoading: boolean };

  const meals = [
    { title: "Breakfast", data: breakfast },
    { title: "Lunch", data: lunch },
    { title: "Dinner", data: dinner },
    { title: "Snacks", data: snacks }
  ];

  return (
    <div className="flex flex-col space-y-4">
      <div className="flex justify-between">
        <h1 className="font-bold text-2xl">Food Diary</h1>
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
        )
      )}
    </div>
  );
}
