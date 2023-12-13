import { Table, TableBody, TableCell, TableHeader, TableRow } from "@/components/ui/table.tsx";
import { useGetSavedFoods } from "@/hooks/useGetSavedFoods.ts";
import SavedFoodsSkeleton from "@/components/saved-foods/saved-foods-skeleton.tsx";

export default function SavedFoodsTable() {
  const { data, isLoading } = useGetSavedFoods();

  if (isLoading)
    return (
      <SavedFoodsSkeleton />
    );

  return <Table>
    <TableHeader>
      <TableRow className="font-medium">
        <TableCell>Name</TableCell>
        <TableCell className="w-20 text-right">Protein</TableCell>
        <TableCell className="w-20 text-right">Carbs</TableCell>
        <TableCell className="w-20 text-right">Fat</TableCell>
        <TableCell className="w-20 text-right">Calories</TableCell>
        <TableCell className="w-20"></TableCell>
      </TableRow>
    </TableHeader>
    <TableBody>
      {data?.savedFoods.map((food) => <TableRow key={food.savedFoodId}>
          <TableCell>{food.name}</TableCell>
          <TableCell className="text-right">{food.protein}</TableCell>
          <TableCell className="text-right">{food.carbs}</TableCell>
          <TableCell className="text-right">{food.fat}</TableCell>
          <TableCell className="text-right">{food.calories}</TableCell>
          <TableCell className="w-20"></TableCell>
        </TableRow>
      )}
    </TableBody>
  </Table>;
}