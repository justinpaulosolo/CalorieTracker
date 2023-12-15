import * as z from "zod";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { Form, FormControl, FormField, FormItem, FormLabel, FormMessage } from "@/components/ui/form.tsx";
import { Input } from "@/components/ui/input.tsx";
import { Button } from "@/components/ui/button.tsx";
import { useCreateNutritionGoal } from "@/hooks/nutrition-goal/useCreateNutritionGoal.ts";
import { useGetNutritionGoal } from "@/hooks/nutrition-goal/useGetNutritionGoal.ts";
import { useUpdateNutritionGoal } from "@/hooks/nutrition-goal/useUpdateNutritionGoal.ts";
import { CreateNutritionGoalDto, UpdateNutritionGoalDto } from "@/utils/types.ts";
import { toast } from "@/components/ui/use-toast.ts";

const schema = z.object({
  protein: z.coerce.number().int().min(0),
  carbs: z.coerce.number().int().min(0),
  fat: z.coerce.number().int().min(0),
  calories: z.coerce.number().int().min(0)
});

// TODO: Default form values not working when doing a hard reload
export default function NutritionGoalForm() {
  const nutritionalGoal = useGetNutritionGoal();
  const createNutritionGoal = useCreateNutritionGoal();
  const updateNutritionGoal = useUpdateNutritionGoal();

  const form = useForm<z.infer<typeof schema>>({
    resolver: zodResolver(schema),
    defaultValues: {
      calories: nutritionalGoal.data?.calories || 0,
      protein: nutritionalGoal.data?.protein || 0,
      carbs: nutritionalGoal.data?.carbs || 0,
      fat: nutritionalGoal.data?.fat || 0
    }
  });

  if (nutritionalGoal.isLoading) return <div>Loading...</div>;

  const onSubmit = async (values: any) => {
    if (nutritionalGoal.data == null) {
      console.log("create", nutritionalGoal.data);
      const payload: CreateNutritionGoalDto = {
        calories: values.calories,
        protein: values.protein,
        carbs: values.carbs,
        fat: values.fat
      };
      await createNutritionGoal.mutateAsync(payload);
    }
    if (nutritionalGoal.data != null) {
      console.log("update", nutritionalGoal.data);
      const payload: UpdateNutritionGoalDto = {
        nutritionGoalId: nutritionalGoal.data.nutritionGoalId,
        calories: values.calories,
        protein: values.protein,
        carbs: values.carbs,
        fat: values.fat
      };
      await updateNutritionGoal.mutateAsync(payload, {
        onSuccess: () => {
          toast({
            title: "Nutrition goal updated",
            description: "Your nutrition goal has been updated."
          });
        }
      });
    }
  };
  return (
    <Form {...form} >
      <form onSubmit={form.handleSubmit(onSubmit)} className="w-1/4 space-y-4">
        <FormField
          control={form.control}
          name="protein"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Protein</FormLabel>
              <FormControl>
                <Input {...field} type="number" className="w-20" />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="carbs"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Carbs</FormLabel>
              <FormControl>
                <Input {...field} type="number" className="w-20" />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <FormField
          control={form.control}
          name="fat"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Fat</FormLabel>
              <FormControl>
                <Input {...field} type="number" className="w-20" />
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
                <Input {...field} type="number" className="w-20" />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />
        <Button type="submit">Update nutritional goal</Button>
      </form>
    </Form>
  );
}