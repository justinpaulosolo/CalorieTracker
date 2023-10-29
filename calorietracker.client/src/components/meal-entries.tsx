import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import {
  Card,
  CardContent,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu";
import { Button } from "@/components/ui/button";
import { MoreHorizontal } from "lucide-react";
import { Skeleton } from "@/components/ui/skeleton";
import {
  useDeleteMealEntry,
  useGetMealEntriesByDateAndType,
} from "@/utils/services/meal-entries-services";
import { MealEntryType } from "@/utils/types";
import { useCallback } from "react";

interface DropdownMenuActionsProps {
  entry: MealEntryType;
  date: string;
  mealType: string;
}

function MealEntry({ date, mealType }: { date: string; mealType: string }) {
  const { data, isLoading, error } = useGetMealEntriesByDateAndType({
    date,
    mealType,
  });

  if (isLoading) {
    return (
      <div className="flex items-center space-x-4">
        <Skeleton className="h-12 w-12 rounded-full" />
        <div className="space-y-2">
          <Skeleton className="h-4 w-[250px]" />
          <Skeleton className="h-4 w-[200px]" />
        </div>
      </div>
    );
  }

  if (error) {
    return <span>Error: {error.message}</span>;
  }

  if (data.length === 0) {
    return null;
  }

  return (
    <Card>
      <CardHeader>
        <CardTitle>{mealType}</CardTitle>
        <CardDescription></CardDescription>
      </CardHeader>
      <CardContent>
        <div className="w-full">
          <Table>
            <TableHeader>
              <TableRow>
                <TableHead className="font-medium">Name</TableHead>
                <TableHead className="font-medium w-20">Proteins</TableHead>
                <TableHead className="font-medium w-20">Carbs</TableHead>
                <TableHead className="font-medium w-20">Fats</TableHead>
                <TableHead className="font-medium w-20">Calories</TableHead>
              </TableRow>
            </TableHeader>
            <TableBody>
              {data.map((entry: MealEntryType) => (
                <TableRow key={entry.foodEntryId}>
                  <TableCell>{entry.foodName}</TableCell>
                  <TableCell>{entry.proteins}</TableCell>
                  <TableCell>{entry.carbs}</TableCell>
                  <TableCell>{entry.fats}</TableCell>
                  <TableCell>{entry.calories}</TableCell>
                  <TableCell className="w-20">
                    <DropdownMenuActions
                      entry={entry}
                      date={date}
                      mealType={mealType}
                    />
                  </TableCell>
                </TableRow>
              ))}
            </TableBody>
          </Table>
        </div>
      </CardContent>
    </Card>
  );
}

function DropdownMenuActions({
  entry,
  date,
  mealType,
}: DropdownMenuActionsProps) {
  const deleteMealEntry = useDeleteMealEntry();

  const handleEdit = useCallback(() => {
    console.log(entry.foodEntryId, "edit");
  }, [entry]);

  const handleDelete = useCallback(() => {
    console.log(entry.foodEntryId, "delete");
    deleteMealEntry.mutateAsync({
      id: entry.foodEntryId,
      date: date,
      mealType: mealType,
    });
  }, [deleteMealEntry, entry, date, mealType]);

  return (
    <DropdownMenu>
      <DropdownMenuTrigger asChild>
        <Button variant="ghost" className="h-8 w-8 p-0">
          <span className="sr-only">Open menu</span>
          <MoreHorizontal className="h-4 w-4" />
        </Button>
      </DropdownMenuTrigger>
      <DropdownMenuContent align="end">
        <DropdownMenuLabel>Actions</DropdownMenuLabel>
        <DropdownMenuItem onClick={handleEdit}>Edit</DropdownMenuItem>
        <DropdownMenuItem onClick={handleDelete}>Delete</DropdownMenuItem>
      </DropdownMenuContent>
    </DropdownMenu>
  );
}

export default MealEntry;
