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
import useCurrentDate from "@/utils/hooks/useCurrentDate";
import { PlusCircledIcon } from "@radix-ui/react-icons";
import { Link } from "react-router-dom";

export default function FoodDiaryTable() {
  const currentDate = useCurrentDate().toString();
  return (
    <div className="flex flex-col space-y-4">
      <Card>
        <CardHeader>
          <div className="flex justify-between items-center">
            <CardTitle>Breakfast</CardTitle>
            <Link to={`/food/add/${currentDate}/Breakfast`}>
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
                <TableHead className="font-medium w-20 text-right">
                  Fat
                </TableHead>
                <TableHead className="font-medium w-20 text-right">
                  Calories
                </TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              <TableRow>
                <TableCell>Chicken Table</TableCell>
                <TableCell className="text-right">20</TableCell>
                <TableCell className="text-right">30</TableCell>
                <TableCell className="text-right">10</TableCell>
                <TableCell className="text-right">500</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Rice</TableCell>
                <TableCell className="text-right">20</TableCell>
                <TableCell className="text-right">30</TableCell>
                <TableCell className="text-right">10</TableCell>
                <TableCell className="text-right">500</TableCell>
              </TableRow>
            </TableBody>
            <TableFooter>
              <TableRow>
                <TableCell colSpan={1}>Total</TableCell>
                <TableCell className="text-right">40</TableCell>
                <TableCell className="text-right">60</TableCell>
                <TableCell className="text-right">20</TableCell>
                <TableCell className="text-right">1000</TableCell>
              </TableRow>
            </TableFooter>
          </Table>
        </CardContent>
      </Card>
      <Card>
        <CardHeader>
          <div className="flex justify-between items-center">
            <CardTitle>Lunch</CardTitle>
            <Link to={`/food/add/${currentDate}/Lunch`}>
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
                <TableHead className="font-medium w-20 text-right">
                  Fat
                </TableHead>
                <TableHead className="font-medium w-20 text-right">
                  Calories
                </TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              <TableRow>
                <TableCell>Chicken Table</TableCell>
                <TableCell className="text-right">20</TableCell>
                <TableCell className="text-right">30</TableCell>
                <TableCell className="text-right">10</TableCell>
                <TableCell className="text-right">500</TableCell>
              </TableRow>
              <TableRow>
                <TableCell>Rice</TableCell>
                <TableCell className="text-right">20</TableCell>
                <TableCell className="text-right">30</TableCell>
                <TableCell className="text-right">10</TableCell>
                <TableCell className="text-right">500</TableCell>
              </TableRow>
            </TableBody>
            <TableFooter>
              <TableRow>
                <TableCell colSpan={1}>Total</TableCell>
                <TableCell className="text-right">40</TableCell>
                <TableCell className="text-right">60</TableCell>
                <TableCell className="text-right">20</TableCell>
                <TableCell className="text-right">1000</TableCell>
              </TableRow>
            </TableFooter>
          </Table>
        </CardContent>
      </Card>
    </div>
  );
}
