import { useGetFoodDiaryByDate } from "@/utils/services/diary-services";
import FoodDiaryTable from "./food-diary-table";
import useCurrentDate from "@/utils/hooks/useCurrentDate";

export default function FoodDiaryPage() {
  const currentDate = useCurrentDate();
  const { data, breakfast, lunch, dinner, snacks, isLoading } =
    useGetFoodDiaryByDate(currentDate);

  if (isLoading) return <div>Loading...</div>;

  return (
    <div className="flex flex-col space-y-4">
      <h1 className="font-bold text-2xl">Food Diary</h1>
      <FoodDiaryTable title="Breakfast" data={breakfast} date={data?.date} />
      <FoodDiaryTable title="Lunch" data={lunch} date={data?.date} />
      <FoodDiaryTable title="Dinner" data={dinner} date={data?.date} />
      <FoodDiaryTable title="Snack" data={snacks} date={data?.date} />
    </div>
  );
}
