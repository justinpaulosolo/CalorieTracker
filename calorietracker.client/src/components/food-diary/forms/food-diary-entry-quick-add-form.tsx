import * as z from "zod";
import { useForm } from "react-hook-form";
import { format } from "date-fns";
import { zodResolver } from "@hookform/resolvers/zod";
import { cn } from "@/lib/utils.ts";
import { Icons } from "@/components/icons.tsx";
import { Button } from "@/components/ui/button.tsx";
import { Calendar } from "@/components/ui/calendar.tsx";
import { Input } from "@/components/ui/input.tsx";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form.tsx";
import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover.tsx";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select.tsx";
import { CreateFoodDiaryEntryDto, useCreateFoodDiaryEntry } from "@/utils/services/diary-services.ts";

import { CalendarIcon } from "@radix-ui/react-icons";
import { toast } from "sonner";

const foodQuickAddFormSchema = z.object({
  date: z.date(),
  mealType: z.enum(["Breakfast", "Lunch", "Dinner", "Snacks"], {
    required_error: "Please select a meal."
  }),
  foodName: z.string(),
  protein: z.coerce.number().int().min(0).max(999),
  carbs: z.coerce.number().int().min(0).max(999),
  fat: z.coerce.number().int().min(0).max(999),
  calories: z.coerce.number().int().min(0).max(9999)
});

export type FoodQuickAddFormValues = z.infer<typeof foodQuickAddFormSchema>;

interface FoodQuickAddFormProps {
  date: Date;
}

export default function FoodDiaryEntryQuickAddForm({ date }: FoodQuickAddFormProps) {
  const { mutateAsync, isPending } = useCreateFoodDiaryEntry(
    format(date, "yyyy-MM-dd")
  );

  const form = useForm<FoodQuickAddFormValues>({
    resolver: zodResolver(foodQuickAddFormSchema),
    defaultValues: {
      mealType: undefined,
      foodName: "",
      protein: 0,
      carbs: 0,
      fat: 0,
      calories: 0,
      date: date
    }
  });

  async function onSubmit(values: FoodQuickAddFormValues) {
    const createFoodDiaryEntryDto: CreateFoodDiaryEntryDto = {
      foodName: values.foodName,
      protein: values.protein,
      carbs: values.carbs,
      fat: values.fat,
      calories: values.calories,
      meal: values.mealType,
      date: format(values.date, "yyyy-MM-dd")
    };

    await mutateAsync(createFoodDiaryEntryDto, {
      onSuccess: () => {
        form.reset();
        toast("Food diary entry added");
      }
    });
  }

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
          name="mealType"
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
          name="foodName"
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
        <Button disabled={isPending} type="submit">
          {isPending ? (
            <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
          ) : (
            "Submit"
          )}
        </Button>
      </form>
    </Form>
  );
}
