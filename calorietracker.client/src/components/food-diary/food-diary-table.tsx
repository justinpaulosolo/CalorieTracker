import React, { useState } from "react";
import { Link } from "react-router-dom";
import { useDeleteFoodDiaryEntry } from "@/utils/services/food-diary-services.ts";
import {
  AlertDialog,
  AlertDialogCancel,
  AlertDialogContent,
  AlertDialogDescription,
  AlertDialogFooter,
  AlertDialogHeader,
  AlertDialogTitle,
} from "@/components/ui/alert-dialog.tsx";
import { Button } from "@/components/ui/button.tsx";
import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card.tsx";
import {
  DropdownMenu,
  DropdownMenuContent,
  DropdownMenuItem,
  DropdownMenuLabel,
  DropdownMenuTrigger,
} from "@/components/ui/dropdown-menu.tsx";
import { DotsHorizontalIcon, PlusCircledIcon } from "@radix-ui/react-icons";
import { Icons } from "@/components/icons.tsx";
import {
  Table,
  TableBody,
  TableCell,
  TableFooter,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table.tsx";
import { Food, FoodDiary } from "@/utils/types.ts";

type FoodDiaryTableProps = {
  data?: FoodDiary;
  title: string;
  date: string;
};

const KEYS: Record<string, keyof Food> = {
  PROTEIN: "protein",
  CARBS: "carbs",
  FAT: "fat",
  CALORIES: "calories",
};

const calculateTotal = (foods: Food[], key: keyof Food) => {
  return foods.reduce((total, food) => total + Number(food[key]), 0);
};

const FoodRow = ({
  food,
  onDeleteClick,
}: {
  food: Food;
  onDeleteClick: (foodId: number) => void;
}) => {
  return (
    <TableRow>
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
              <DotsHorizontalIcon />
            </Button>
          </DropdownMenuTrigger>
          <DropdownMenuContent align="end">
            <DropdownMenuLabel>Actions</DropdownMenuLabel>
            <DropdownMenuItem
              onClick={() => onDeleteClick(food.foodDiaryEntryId)}
              className="text-red-600 cursor-pointer"
            >
              Delete
            </DropdownMenuItem>
          </DropdownMenuContent>
        </DropdownMenu>
      </TableCell>
    </TableRow>
  );
};

const FoodDiaryTable: React.FC<FoodDiaryTableProps> = ({
  data,
  title,
  date,
}) => {
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [selectedFoodDiaryEntryId, setSelectedFoodDiaryEntryId] = useState<
    number | undefined
  >(undefined);
  const { mutate, isPending } = useDeleteFoodDiaryEntry();

  const totalProtein = calculateTotal(data?.foods || [], KEYS.PROTEIN);
  const totalCarbs = calculateTotal(data?.foods || [], KEYS.CARBS);
  const totalFat = calculateTotal(data?.foods || [], KEYS.FAT);
  const totalCalories = calculateTotal(data?.foods || [], KEYS.CALORIES);

  const handleOnDeleteClick = (foodDiaryEntryId: number) => {
    setSelectedFoodDiaryEntryId(foodDiaryEntryId);
    setShowDeleteDialog(true);
  };

  const handleOnDeleteConfirm = () => {
    if (!selectedFoodDiaryEntryId) return;
    mutate(selectedFoodDiaryEntryId);
    setSelectedFoodDiaryEntryId(undefined);
    setShowDeleteDialog(false);
  };

  return (
    <Card>
      <CardHeader>
        <div className="flex justify-between items-center">
          <CardTitle>{title}</CardTitle>
          <Link to={`/food-diary/detailed/new/${date!.split("T")[0]}/${title}`}>
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
              <TableHead className="w-20"></TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {data?.foods &&
              data.foods.map((food, index) => (
                <FoodRow
                  key={index}
                  food={food}
                  onDeleteClick={handleOnDeleteClick}
                />
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
      <AlertDialog open={showDeleteDialog} onOpenChange={setShowDeleteDialog}>
        <AlertDialogContent>
          <AlertDialogHeader>
            <AlertDialogTitle>Are you sure absolutely sure?</AlertDialogTitle>
            <AlertDialogDescription>
              This action cannot be undone.
            </AlertDialogDescription>
          </AlertDialogHeader>
          <AlertDialogFooter>
            <AlertDialogCancel>Cancel</AlertDialogCancel>
            <Button variant="destructive" onClick={handleOnDeleteConfirm}>
              {isPending ? (
                <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
              ) : (
                "Delete"
              )}
            </Button>
          </AlertDialogFooter>
        </AlertDialogContent>
      </AlertDialog>
    </Card>
  );
};

export default FoodDiaryTable;
