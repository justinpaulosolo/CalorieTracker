import SavedFoodsTable from "@/components/saved-foods/saved-foods-table.tsx";
import { Button } from "@/components/ui/button.tsx";
import { useNavigate } from "react-router-dom";

export default function SavedFoodPage() {
  const navigate = useNavigate();
  return (
    <div className="flex flex-col space-y-4">
      <div className="flex justify-between">
        <h1 className="font-bold text-2xl">Saved Foods</h1>
        <Button onClick={() => navigate("/saved-foods/new")}>Create Saved Food</Button>
      </div>
      <SavedFoodsTable />
    </div>
  );
}
