import * as z from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form.tsx";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { EditMealEntry, MealEntryTypeEnums } from "@/utils/types";
import { useEditMealEntry } from "@/utils/services/meal-services";
import { useNavigate } from "react-router-dom";

const editMealEntrySchema = z.object({
  mealFoodEntryId: z.number(),
  mealType: z.enum(["Breakfast", "Lunch", "Dinner", "Other"], {
    required_error: "Please select a meal.",
  }),
  name: z.string().min(2, "Name must be at least characters"),
  proteins: z.coerce.number({
    required_error: "Please enter protein amount.",
  }),
  carbohydrates: z.coerce.number({
    required_error: "Please enter carbohydrate amount.",
  }),
  fats: z.coerce.number({ required_error: "Please enter fat amount." }),
  calories: z.coerce.number({
    required_error: "Please enter calorie amount.",
  }),
});

type EditMealEntryFormValues = z.infer<typeof editMealEntrySchema>;

interface EditMealEntryFormProps {
  mealEntry: EditMealEntry;
}

export default function EditMealEntryForm(
  EditMealEntryFormProps: EditMealEntryFormProps
) {
  const mealEntry = EditMealEntryFormProps.mealEntry;
  const editMealEntry = useEditMealEntry();
  const navigate = useNavigate();

  const form = useForm<EditMealEntryFormValues>({
    resolver: zodResolver(editMealEntrySchema),
    defaultValues: {
      mealFoodEntryId: mealEntry.foodMealEntryId,
      mealType: mealEntry.mealType as MealEntryTypeEnums,
      name: mealEntry.foodName,
      proteins: mealEntry.proteins,
      carbohydrates: mealEntry.carbohydrates,
      fats: mealEntry.fats,
      calories: mealEntry.calories,
    },
  });

  async function onSubmit(data: EditMealEntryFormValues) {
    const payload: EditMealEntry = {
      foodMealEntryId: data.mealFoodEntryId,
      mealType: data.mealType,
      foodName: data.name,
      proteins: data.proteins,
      carbohydrates: data.carbohydrates,
      fats: data.fats,
      calories: data.calories,
      date: mealEntry.date,
    };
    await editMealEntry.mutateAsync(payload, {
      onSuccess: () => navigate("/"),
    });
  }

  return (
    <Form {...form}>
      <form
        onSubmit={form.handleSubmit(onSubmit)}
        className="flex flex-col max-w-sm space-y-4 mx-auto mt-10"
      >
        <FormField
          control={form.control}
          name="mealType"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Meal</FormLabel>
              <Select onValueChange={field.onChange} defaultValue={field.value}>
                <FormControl>
                  <SelectTrigger className="rounded-lg">
                    <SelectValue placeholder="Select" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  <SelectItem value="Breakfast">Breakfast</SelectItem>
                  <SelectItem value="Lunch">Lunch</SelectItem>
                  <SelectItem value="Dinner">Dinner</SelectItem>
                  <SelectItem value="Other">Other</SelectItem>
                </SelectContent>
              </Select>
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="name"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Food name</FormLabel>
              <FormControl>
                <Input {...field} className="rounded-lg" />
              </FormControl>
            </FormItem>
          )}
        />
        <div className="flex justify-between">
          <FormField
            control={form.control}
            name="proteins"
            render={({ field }) => (
              <FormItem className="align-middle">
                <FormLabel>Proteins</FormLabel>
                <FormControl>
                  <Input {...field} type="number" className="w-20 rounded-lg" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="carbohydrates"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Carbohydrates</FormLabel>
                <FormControl>
                  <Input {...field} className="w-20 rounded-lg" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="fats"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Fats</FormLabel>
                <FormControl>
                  <Input {...field} className="w-20 rounded-lg" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
          <FormField
            control={form.control}
            name="calories"
            render={({ field }) => (
              <FormItem>
                <FormLabel>Calories</FormLabel>
                <FormControl>
                  <Input {...field} className="w-20 rounded-lg" />
                </FormControl>
                <FormMessage />
              </FormItem>
            )}
          />
        </div>
        <div className="flex flex-col-reverse">
          <Button type="submit">Submit</Button>
        </div>
      </form>
    </Form>
  );
}
