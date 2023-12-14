import { Table, TableBody, TableCell, TableHeader, TableRow } from "@/components/ui/table.tsx";
import { useGetSavedFoods } from "@/hooks/useGetSavedFoods.ts";
import SavedFoodsSkeleton from "@/components/saved-foods/saved-foods-skeleton.tsx";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger
} from "@/components/ui/dropdown-menu.tsx";
import { Button } from "@/components/ui/button.tsx";
import { DotsHorizontalIcon } from "@radix-ui/react-icons";

export default function SavedFoodsTable() {
  const { data, isLoading } = useGetSavedFoods();

  if (isLoading)
    return (
      <SavedFoodsSkeleton />
    );

  const onDeleteClick = async (id: number) => {
    console.log(`Deleting ${id}`);
  };

  return <Table>
    <TableHeader>
      <TableRow className="font-medium">
        <TableCell>Name</TableCell>
        <TableCell className="w-20 text-right">Protein</TableCell>
        <TableCell className="w-20 text-right">Carbs</TableCell>
        <TableCell className="w-20 text-right">Fat</TableCell>
        <TableCell className="w-20 text-right">Calories</TableCell>
        <TableCell className="w-10"></TableCell>
      </TableRow>
    </TableHeader>
    <TableBody>
      {data?.savedFoods.map((food) => <TableRow key={food.savedFoodId}>
          <TableCell>{food.name}</TableCell>
          <TableCell className="text-right">{food.protein}</TableCell>
          <TableCell className="text-right">{food.carbs}</TableCell>
          <TableCell className="text-right">{food.fat}</TableCell>
          <TableCell className="text-right">{food.calories}</TableCell>
          <TableCell className="w-10">
            <DropdownMenu>
              <DropdownMenuTrigger asChild>
                <Button variant="ghost" className="h-8 w-8 p-0">
                  <span className="sr-only">Open menu</span>
                  <DotsHorizontalIcon />
                </Button>
              </DropdownMenuTrigger>
              <DropdownMenuContent align="end">
                <DropdownMenuLabel>Actions</DropdownMenuLabel>
                <DropdownMenuItem
                  onClick={() => onDeleteClick(food.savedFoodId)}
                  className="text-red-600 cursor-pointer"
                >
                  Delete
                </DropdownMenuItem>
              </DropdownMenuContent>
            </DropdownMenu>
          </TableCell>
        </TableRow>
      )}
    </TableBody>
  </Table>;
}