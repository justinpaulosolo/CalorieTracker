import * as z from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form.tsx";
import { Popover, PopoverContent, PopoverTrigger } from "@/components/ui/popover.tsx";
import { Button } from "@/components/ui/button.tsx";
import { cn } from "@/lib/utils.ts";
import { format } from "date-fns";
import { CalendarIcon } from "@radix-ui/react-icons";
import { Calendar } from "@/components/ui/calendar.tsx";
import { Select, SelectContent, SelectItem, SelectTrigger, SelectValue } from "@/components/ui/select.tsx";
import { Icons } from "@/components/icons.tsx";
import { useGetSavedFoods } from "@/hooks/useGetSavedFoods.ts";
import { CreateFoodDiaryEntryDto, useCreateFoodDiaryEntry } from "@/utils/services/diary-services.ts";

const foodDiaryEntryAddFormSchema = z.object({
  date: z.date(),
  mealType: z.enum(["Breakfast", "Lunch", "Dinner", "Snacks"], {
    required_error: "Please select a meal."
  }),
  savedFoodId: z.string()
});

export default function FoodDiaryEntryAddForm({ date }: { date: Date }) {
  const createFoodDiaryEntry = useCreateFoodDiaryEntry(format(date, "yyyy-MM-dd"));
  const savedFoods = useGetSavedFoods();

  const form = useForm<z.infer<typeof foodDiaryEntryAddFormSchema>>({
    resolver: zodResolver(foodDiaryEntryAddFormSchema),
    defaultValues: {
      mealType: undefined,
      savedFoodId: undefined,
      date: date
    }
  });

  const onSubmit = async (values: z.infer<typeof foodDiaryEntryAddFormSchema>) => {
    const food = savedFoods.data?.savedFoods.find((food) => food.savedFoodId === Number(values.savedFoodId));
    const payload: CreateFoodDiaryEntryDto = {
      date: format(values.date, "yyyy-MM-dd"),
      meal: values.mealType,
      foodName: food!.name,
      protein: food!.protein,
      carbs: food!.carbs,
      fat: food!.fat,
      calories: food!.calories
    };

    await createFoodDiaryEntry.mutateAsync(payload);
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onSubmit)} className="flex flex-col space-y-4">
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
            <FormItem className="flex justify-between">
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
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="savedFoodId"
          render={({ field }) => (
            <FormItem className="flex justify-between">
              <FormLabel>Saved Foods</FormLabel>
              <Select
                onValueChange={field.onChange}
                defaultValue={field.value}
              >
                <FormControl>
                  <SelectTrigger className="w-[200px]">
                    <SelectValue placeholder="Select Food" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {savedFoods.data?.savedFoods.map((food) => (
                    <SelectItem key={food.savedFoodId} value={food.savedFoodId.toString()}>
                      {food.name}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button disabled={createFoodDiaryEntry.isPending} type="submit">
          {createFoodDiaryEntry.isPending ? (
            <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
          ) : (
            "Submit"
          )}
        </Button>
      </form>
    </Form>
  );


}