import { useGetFoodDiaryByDate } from "@/utils/services/diary-services";
import FoodDiaryTable from "./food-diary-table";
import useCurrentDate from "@/utils/hooks/useCurrentDate";
import FoodDiaryTableSkeleton from "./food-diary-table-skeleton";

export default function FoodDiaryPage() {
  const currentDate = useCurrentDate();
  const { data, breakfast, lunch, dinner, snacks, isLoading } =
    useGetFoodDiaryByDate(currentDate);

  const meals = [
    { title: "Breakfast", data: breakfast },
    { title: "Lunch", data: lunch },
    { title: "Dinner", data: dinner },
    { title: "Snacks", data: snacks },
  ];

  return (
    <div className="flex flex-col space-y-4">
      <h1 className="font-bold text-2xl">Food Diary</h1>
      {isLoading
        ? Array(4).fill(<FoodDiaryTableSkeleton />)
        : meals.map(meal => (
            <FoodDiaryTable
              key={meal.title}
              title={meal.title}
              data={meal.data}
              date={data?.date}
            />
          ))}
    </div>
  );
}
