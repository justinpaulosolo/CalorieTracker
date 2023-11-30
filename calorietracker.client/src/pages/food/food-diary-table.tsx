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
import { useMemo } from "react";

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
    () => calculateTotal(data!.foods, "protein"),
    [data]
  );
  const totalCarbs = useMemo(
    () => calculateTotal(data!.foods, "carbs"),
    [data]
  );
  const totalFat = useMemo(() => calculateTotal(data!.foods, "fat"), [data]);
  const totalCalories = useMemo(
    () => calculateTotal(data!.foods, "calories"),
    [data]
  );
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
            {data?.foods.map(food => (
              <TableRow key={food.foodId}>
                <TableCell>{food.name}</TableCell>
                <TableCell className="text-right">{food.protein}</TableCell>
                <TableCell className="text-right">{food.carbs}</TableCell>
                <TableCell className="text-right">{food.fat}</TableCell>
                <TableCell className="text-right">{food.calories}</TableCell>
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
            </TableRow>
          </TableFooter>
        </Table>
      </CardContent>
    </Card>
  );
}
