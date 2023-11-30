import { Button } from "@/components/ui/button";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { FoodDiary } from "@/utils/types";
import { PlusCircledIcon } from "@radix-ui/react-icons";
import { Link } from "react-router-dom";

type FoodDiaryTableProps = {
  data?: FoodDiary;
  title: string;
  date?: string;
};

export default function FoodDiaryTable(props: FoodDiaryTableProps) {
  const { data, title, date } = props;
  console.log(data);
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
          {/* <TableFooter>
            <TableRow>
              <TableCell colSpan={1}>Total</TableCell>
              <TableCell className="text-right">40</TableCell>
              <TableCell className="text-right">60</TableCell>
              <TableCell className="text-right">20</TableCell>
              <TableCell className="text-right">1000</TableCell>
            </TableRow>
          </TableFooter> */}
        </Table>
      </CardContent>
    </Card>
  );
}
