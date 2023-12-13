import SavedFoodsTable from "@/components/saved-foods-table.tsx";

export default function SavedFoodPage() {
  return (
    <div className="flex flex-col space-y-4">
      <h1 className="font-bold text-2xl">Saved Foods</h1>
      <SavedFoodsTable />
    </div>
  );
}
