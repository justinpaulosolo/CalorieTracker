import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { Button, buttonVariants } from "@/components/ui/button";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form.tsx";
import { Input } from "@/components/ui/input";
import { cn } from "@/lib/utils";
import { ChevronDownIcon } from "@radix-ui/react-icons";
import { useParams } from "react-router-dom";
import { useCreateFoodDiaryEntry } from "@/utils/services/food-diary-services";
import { useTestingMutation } from "@/utils/services/testing-services";
import { Icons } from "@/components/icons";

const foodQuickAddFormSchema = z.object({
  date: z.string().regex(/^\d{4}-\d{2}-\d{2}$/),
  meal: z.number().nonnegative().int(),
  foodName: z.string(),
  protein: z.coerce.number().int().min(0).max(999),
  carbs: z.coerce.number().int().min(0).max(999),
  fat: z.coerce.number().int().min(0).max(999),
  calories: z.coerce.number().int().min(0).max(9999),
});

enum MealType {
  Breakfast = 1,
  Lunch = 2,
  Dinner = 3,
  Snack = 4,
}

export type FoodQuickAddFormValues = z.infer<typeof foodQuickAddFormSchema>;

export default function FoodQuickAddForm() {
  const { date, meal } = useParams<{
    date: string;
    meal: string;
  }>();
  const { mutate, isPending } = useTestingMutation();

  const form = useForm<FoodQuickAddFormValues>({
    resolver: zodResolver(foodQuickAddFormSchema),
    defaultValues: {
      meal: MealType[meal as keyof typeof MealType],
      foodName: "",
      protein: 0,
      carbs: 0,
      fat: 0,
      calories: 0,
      date: date,
    },
  });

  function onSubmit(values: FoodQuickAddFormValues) {
    console.log(values);
    mutate();
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="flex flex-col space-y-4"
      >
        <FormField
          control={form.control}
          name="meal"
          render={({ field }) => (
            <FormItem>
              <div className="flex justify-between">
                <FormLabel>Meal</FormLabel>
                <div className="relative w-max">
                  <FormControl>
                    <>
                      <select
                        disabled
                        className={cn(
                          buttonVariants({ variant: "outline" }),
                          "w-[200px] appearance-none bg-transparent font-normal"
                        )}
                        {...field}
                      >
                        <option value={1}>Breakfast</option>
                        <option value={2}>Lunch</option>
                        <option value={3}>Dinner</option>
                        <option value={4}>Snack</option>
                      </select>
                      <input type="hidden" name="meal" value={field.value} />
                    </>
                  </FormControl>
                  <ChevronDownIcon className="absolute right-3 top-2.5 h-4 w-4 opacity-50" />
                </div>
              </div>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          disabled={isPending}
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
          disabled={isPending}
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
          disabled={isPending}
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
          disabled={isPending}
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
          disabled={isPending}
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
