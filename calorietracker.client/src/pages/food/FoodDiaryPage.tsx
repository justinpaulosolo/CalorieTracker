import FoodDiaryTable from "./food-diary-table";

export default function FoodDiaryPage() {
  return (
    <div className="flex flex-col space-y-4">
      <h1 className="font-bold text-2xl">Food Diary</h1>
      <FoodDiaryTable />
    </div>
  );
}
