import * as z from "zod";
import { FoodDiaryEntry, MealTypes, UpdateFoodDiaryEntryDto } from "@/utils/types";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Form, FormControl, FormItem, FormLabel, FormMessage } from "@/components/ui/form";
import { FormField } from "@/components/ui/form.tsx";
import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover.tsx";
import { Button } from "@/components/ui/button.tsx";
import { cn } from "@/lib/utils.ts";
import { format } from "date-fns";
import { CalendarIcon } from "@radix-ui/react-icons";
import { Calendar } from "@/components/ui/calendar.tsx";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select.tsx";
import { Input } from "@/components/ui/input.tsx";
import { Icons } from "@/components/icons";
import { useUpdateFoodDiaryEntry } from "@/hooks/useUpdateFoodDiaryEntry.ts";
import { useNavigate } from "react-router-dom";
import { toast } from "@/components/ui/use-toast.ts";
import { useDeleteFoodDiaryEntry } from "@/utils/services/food-diary-services.ts";

const foodDiaryEntryUpdateFormSchema = z.object({
  date: z.date(),
  meal: z.enum(["Breakfast", "Lunch", "Dinner", "Snacks"]),
  name: z.string(),
  protein: z.coerce.number().int().min(0).max(999),
  carbs: z.coerce.number().int().min(0).max(999),
  fat: z.coerce.number().int().min(0).max(999),
  calories: z.coerce.number().int().min(0).max(9999)
});

type FoodDiaryEntryEditFormValues = z.infer<typeof foodDiaryEntryUpdateFormSchema>;

interface FoodDiaryEntryEditFormProps {
  foodDiaryEntry: FoodDiaryEntry;
}

export default function UpdateFoodDiaryEntryForm({ foodDiaryEntry }: FoodDiaryEntryEditFormProps) {
  const deleteFoodDiaryEntry = useDeleteFoodDiaryEntry();
  const updateFoodDiaryEntry = useUpdateFoodDiaryEntry(foodDiaryEntry.foodDiaryEntryId!);

  const navigate = useNavigate();

  const form = useForm<FoodDiaryEntryEditFormValues>({
    resolver: zodResolver(foodDiaryEntryUpdateFormSchema),
    defaultValues: {
      name: foodDiaryEntry.name,
      protein: foodDiaryEntry.protein,
      carbs: foodDiaryEntry.carbs,
      fat: foodDiaryEntry.fat,
      calories: foodDiaryEntry.calories,
      date: new Date(foodDiaryEntry.date),
      meal: foodDiaryEntry.meal as MealTypes
    }
  });

  const onSubmit = async (values: FoodDiaryEntryEditFormValues) => {
    const payload: UpdateFoodDiaryEntryDto = {
      protein: values.protein,
      carbs: values.carbs,
      fat: values.fat,
      calories: values.calories,
      name: values.name,
      date: format(values.date, "yyyy-MM-dd"),
      meal: values.meal
    };

    await updateFoodDiaryEntry.mutateAsync(payload, {
      onSuccess: () => {
        form.reset();
        toast({
          title: "Food diary entry updated",
          description: "Your food diary entry has been updated successfully."
        });
        navigate("/food-diary");
      }
    });
  };

  const handleDelete = async (foodDiaryEntryId: number) => {
    await deleteFoodDiaryEntry.mutateAsync(foodDiaryEntryId, {
      onSuccess: () => {
        toast({
          title: "Food diary entry deleted",
          description: "Your food diary entry has been deleted successfully."
        });
        navigate("/food-diary");
      }
    });
  };

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="flex flex-col space-y-4"
      >
        <FormField
          control={form.control}
          name="date"
          render={({ field }) => (
            <FormItem className="flex justify-between">
              <FormLabel>Date</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button
                      variant={"outline"}
                      className={cn(
                        "w-[200px] pl-3 text-left font-normal",
                        !field.value && "text-muted-foreground"
                      )}
                    >
                      {field.value ? (
                        format(field.value, "yyyy-MM-dd")
                      ) : (
                        <span>Pick a date</span>
                      )}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="w-auto p-0" align="start">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="meal"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Meal</FormLabel>
                <Select
                  onValueChange={field.onChange}
                  defaultValue={field.value}
                >
                  <FormControl>
                    <SelectTrigger className="w-[200px]">
                      <SelectValue placeholder="Select a meal" />
                    </SelectTrigger>
                  </FormControl>
                  <SelectContent>
                    <SelectItem value="Breakfast">Breakfast</SelectItem>
                    <SelectItem value="Lunch">Lunch</SelectItem>
                    <SelectItem value="Dinner">Dinner</SelectItem>
                    <SelectItem value="Snacks">Snack</SelectItem>
                  </SelectContent>
                </Select>
              </div>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Food name</FormLabel>
                <FormControl>
                  <Input {...field} className="rounded-lg w-[200px]" />
                </FormControl>
              </div>
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="protein"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Protein</FormLabel>
                <FormControl>
                  <Input {...field} type="number" className="w-20" />
                </FormControl>
              </div>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="carbs"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Carbs</FormLabel>
                <FormControl>
                  <Input {...field} type="number" className="w-20" />
                </FormControl>
              </div>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="fat"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Fat</FormLabel>
                <FormControl>
                  <Input {...field} type="number" className="w-20" />
                </FormControl>
              </div>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="calories"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Calories</FormLabel>
                <FormControl>
                  <Input {...field} type="number" className="w-20" />
                </FormControl>
              </div>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button disabled={updateFoodDiaryEntry.isPending || deleteFoodDiaryEntry.isPending} type="submit">
          {updateFoodDiaryEntry.isPending ? (
            <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
          ) : (
            "Update"
          )}
        </Button>
        <div className="relative">
          <div className="absolute inset-0 flex items-center">
            <span className="w-full border-t" />
          </div>
          <div className="relative flex justify-center text-xs uppercase">
          <span className="bg-background px-2 text-muted-foreground">
            Or
          </span>
          </div>
        </div>
        <Button type="button" variant="destructive"
                disabled={deleteFoodDiaryEntry.isPending || updateFoodDiaryEntry.isPending}
                onClick={() => handleDelete(foodDiaryEntry.foodDiaryEntryId!)}>
          {deleteFoodDiaryEntry.isPending ? (
            <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
          ) : (
            "Delete"
          )}
        </Button>
      </form>
    </Form>
  );
}