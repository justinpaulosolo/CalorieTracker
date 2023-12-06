import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import * as z from "zod";
import { Button } from "@/components/ui/button.tsx";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form.tsx";
import { Input } from "@/components/ui/input.tsx";
import {
  CreateFoodDiaryEntryDto,
  useCreateFoodDiaryEntry,
} from "@/utils/services/diary-services.ts";
import { Icons } from "@/components/icons.tsx";
import { format } from "date-fns";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select.tsx";
import { useParams } from "react-router-dom";

const foodQuickAddFormSchema = z.object({
  date: z.string().regex(/^\d{4}-\d{2}-\d{2}$/),
  meal: z.string(),
  foodName: z.string(),
  protein: z.coerce.number().int().min(0).max(999),
  carbs: z.coerce.number().int().min(0).max(999),
  fat: z.coerce.number().int().min(0).max(999),
  calories: z.coerce.number().int().min(0).max(9999),
});

export type FoodQuickAddFormValues = z.infer<typeof foodQuickAddFormSchema>;

interface FoodQuickAddFormProps {
  date?: Date;
  onSuccessfulSubmit?: () => void;
}

export default function FoodQuickAddForm({
  date: dateProp,
  onSuccessfulSubmit,
}: FoodQuickAddFormProps) {
  const { date: dateParam, meal: mealParam } = useParams<{
    date?: string;
    meal?: string;
  }>();

  const { mutateAsync, isPending } = useCreateFoodDiaryEntry(
    dateParam ?? format(dateProp!, "yyyy-MM-dd"),
  );

  const form = useForm<FoodQuickAddFormValues>({
    resolver: zodResolver(foodQuickAddFormSchema),
    defaultValues: {
      meal: mealParam ?? "",
      foodName: "",
      protein: 0,
      carbs: 0,
      fat: 0,
      calories: 0,
      date: dateParam ?? format(dateProp!, "yyyy-MM-dd"),
    },
  });

  async function onSubmit(values: FoodQuickAddFormValues) {
    console.log(values);
    const createFoodDiaryEntryDto: CreateFoodDiaryEntryDto = {
      foodName: values.foodName,
      protein: values.protein,
      carbs: values.carbs,
      fat: values.fat,
      calories: values.calories,
      meal: values.meal,
      date: values.date,
    };
    await mutateAsync(createFoodDiaryEntryDto, {
      onSuccess: () => {
        form.reset();
        return onSuccessfulSubmit;
      },
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
          name="meal"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Email</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger>
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
