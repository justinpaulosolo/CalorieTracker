import { useForm } from "react-hook-form";
import { useParams } from "react-router-dom";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form.tsx";
import { Input } from "@/components/ui/input";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import * as z from "zod";
import { Button } from "@/components/ui/button";

const editFoodEntrySchema = z.object({
  id: z.number(),
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

type EditFoodEntryFormValues = z.infer<typeof editFoodEntrySchema>;

export default function EditFoodEntryPage() {
  const { id } = useParams();
  const form = useForm<EditFoodEntryFormValues>({
    resolver: zodResolver(editFoodEntrySchema),
    defaultValues: {
      id: Number(id),
      name: "",
      proteins: 0,
      carbohydrates: 0,
      fats: 0,
      calories: 0,
    },
  });

  async function onSubmit(data: EditFoodEntryFormValues) {
    console.log(data);
  }

  return (
    <div>
      <h1>Edit Food Entry</h1>
      <p>Food Entry ID: {id}</p>
      <div>
        <Form {...form}>
          <form
            onSubmit={form.handleSubmit(onSubmit)}
            className="flex justify-between"
          >
            <div className="w-28">
              <FormField
                control={form.control}
                name="mealType"
                render={({ field }) => (
                  <FormItem>
                    <FormLabel>Meal</FormLabel>
                    <Select
                      onValueChange={field.onChange}
                      defaultValue={field.value}
                    >
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
            </div>
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
            <FormField
              control={form.control}
              name="proteins"
              defaultValue={0}
              render={({ field }) => (
                <FormItem className="align-middle">
                  <FormLabel>Protein</FormLabel>
                  <FormControl>
                    <Input
                      {...field}
                      type="number"
                      className="w-20 rounded-lg"
                    />
                  </FormControl>
                  <FormMessage />
                </FormItem>
              )}
            />
            <FormField
              control={form.control}
              name="carbohydrates"
              defaultValue={0}
              render={({ field }) => (
                <FormItem>
                  <FormLabel>Cabs</FormLabel>
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
              defaultValue={0}
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
              defaultValue={0}
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
            <div className="flex flex-col-reverse">
              <Button type="submit">Submit</Button>
            </div>
          </form>
        </Form>
      </div>
    </div>
  );
}
