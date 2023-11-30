import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Table,
  TableBody,
  TableCell,
  TableFooter,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Food, FoodDiary } from "@/utils/types";
import { PlusCircledIcon } from "@radix-ui/react-icons";
import { Link } from "react-router-dom";
import { useCallback, useMemo } from "react";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { MoreHorizontal } from "lucide-react";

type FoodDiaryTableProps = {
  data?: FoodDiary;
  title: string;
  date?: string;
};

function calculateTotal(foods: Food[], key: keyof Food) {
  return foods.reduce((total, food) => total + Number(food[key]), 0);
}

export default function FoodDiaryTable({
  data,
  title,
  date,
}: FoodDiaryTableProps) {
  const totalProtein = useMemo(
    () => calculateTotal(data?.foods || [], "protein"),
    [data]
  );
  const totalCarbs = useMemo(
    () => calculateTotal(data?.foods || [], "carbs"),
    [data]
  );
  const totalFat = useMemo(
    () => calculateTotal(data?.foods || [], "fat"),
    [data]
  );
  const totalCalories = useMemo(
    () => calculateTotal(data?.foods || [], "calories"),
    [data]
  );

  const handleDelete = useCallback((foodId: number) => {
    console.log(foodId, "delete");
  }, []);

  const handleEdit = useCallback((foodId: number) => {
    console.log(foodId, "edit");
  }, []);
  return (
    <Card>
      <CardHeader>
        <div className="flex justify-between items-center">
          <CardTitle>{title}</CardTitle>
          <Link to={`/food/add/${date!.split("T")[0]}/${title}`}>
            <Button variant="default">
              <PlusCircledIcon className="mr-2 h-4 w-4" />
              Add Food
            </Button>
          </Link>
        </div>
      </CardHeader>
      <CardContent>
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead className="font-medium">Name</TableHead>
              <TableHead className="font-medium w-20 text-right">
                Protein
              </TableHead>
              <TableHead className="font-medium w-20 text-right">
                Carbs
              </TableHead>
              <TableHead className="font-medium w-20 text-right">Fat</TableHead>
              <TableHead className="font-medium w-20 text-right">
                Calories
              </TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {data?.foods.map((food: Food) => (
              <TableRow key={food.foodId}>
                <TableCell>{food.name}</TableCell>
                <TableCell className="text-right">{food.protein}</TableCell>
                <TableCell className="text-right">{food.carbs}</TableCell>
                <TableCell className="text-right">{food.fat}</TableCell>
                <TableCell className="text-right">{food.calories}</TableCell>
                <TableCell className="w-20">
                  <DropdownMenu>
                    <DropdownMenuTrigger asChild>
                      <Button variant="ghost" className="h-8 w-8 p-0">
                        <span className="sr-only">Open menu</span>
                        <MoreHorizontal className="h-4 w-4" />
                      </Button>
                    </DropdownMenuTrigger>
                    <DropdownMenuContent align="end">
                      <DropdownMenuLabel>Actions</DropdownMenuLabel>
                      <DropdownMenuItem onClick={() => handleEdit(food.foodId)}>
                        Edit
                      </DropdownMenuItem>
                      <DropdownMenuItem
                        onClick={() => handleDelete(food.foodId)}
                      >
                        Delete
                      </DropdownMenuItem>
                    </DropdownMenuContent>
                  </DropdownMenu>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
          <TableFooter className="bg-secondary text-black">
            <TableRow>
              <TableCell colSpan={1}>Total</TableCell>
              <TableCell className="text-right">{totalProtein}</TableCell>
              <TableCell className="text-right">{totalCarbs}</TableCell>
              <TableCell className="text-right">{totalFat}</TableCell>
              <TableCell className="text-right">{totalCalories}</TableCell>
              <TableCell className="w-20"></TableCell>
            </TableRow>
          </TableFooter>
        </Table>
      </CardContent>
    </Card>
  );
}
