import * as z from "zod";
import { zodResolver } from "@hookform/resolvers/zod";
import { useForm } from "react-hook-form";
import { Form, FormControl, FormField, FormItem, FormLabel } from "@/components/ui/form.tsx";
import { Input } from "@/components/ui/input.tsx";
import { Button } from "@/components/ui/button.tsx";
import { Icons } from "@/components/icons.tsx";
import { useCreateSavedFood } from "@/hooks/useCreateSavedFood.ts";
import { CreateSavedFoodDto } from "@/utils/types.ts";
import { useNavigate } from "react-router-dom";
import { toast } from "@/components/ui/use-toast.ts";

const savedFoodFormSchema = z.object({
  name: z.string(),
  protein: z.coerce.number().int().min(0).max(999),
  carbs: z.coerce.number().int().min(0).max(999),
  fat: z.coerce.number().int().min(0).max(999),
  calories: z.coerce.number().int().min(0).max(9999)
});

type SavedFoodFormValues = z.infer<typeof savedFoodFormSchema>;

export default function CreateSavedFoodForm() {
  const { mutateAsync, isPending } = useCreateSavedFood();
  const navigate = useNavigate();
  const form = useForm<SavedFoodFormValues>({
    resolver: zodResolver(savedFoodFormSchema),
    defaultValues: {
      name: "",
      protein: 0,
      carbs: 0,
      fat: 0,
      calories: 0
    }
  });

  const onsubmit = async (values: SavedFoodFormValues) => {
    const payload: CreateSavedFoodDto = { ...values };
    await mutateAsync(payload, {
      onSuccess: () => {
        toast({
          title: "Saved food created",
          description: "Your saved food has been created."
        });
        navigate("/saved-foods");
      }
    });
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(onsubmit)} className="flex flex-col space-y-4">
        <FormField render={({ field }) => (
          <FormItem className="flex justify-between">
            <FormLabel>Name</FormLabel>
            <FormControl>
              <Input {...field} className="w-[200px]" />
            </FormControl>
          </FormItem>
        )} name="name" />
        <FormField render={({ field }) => (
          <FormItem className="flex justify-between">
            <FormLabel>Protein</FormLabel>
            <FormControl>
              <Input {...field} type="number" className="w-20" />
            </FormControl>
          </FormItem>
        )} name="protein" />
        <FormField render={({ field }) => (
          <FormItem className="flex justify-between">
            <FormLabel>Carbs</FormLabel>
            <FormControl>
              <Input {...field} type="number" className="w-20" />
            </FormControl>
          </FormItem>
        )} name="carbs" />
        <FormField render={({ field }) => (
          <FormItem className="flex justify-between">
            <FormLabel>Fat</FormLabel>
            <FormControl>
              <Input {...field} type="number" className="w-20" />
            </FormControl>
          </FormItem>
        )} name="fat" />
        <FormField render={({ field }) => (
          <FormItem className="flex justify-between">
            <FormLabel>Calories</FormLabel>
            <FormControl>
              <Input {...field} type="number" className="w-20" />
            </FormControl>
          </FormItem>
        )} name="calories" />
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