import EditMealFoodEntryForm from "@/components/edit-meal-food-entry-form";
import { useGetMealEntriesById } from "@/utils/services/meal-services";
import { useParams } from "react-router-dom";

export default function EditFoodEntryPage() {
  const { id } = useParams();
  const foodEntryId = Number(id);
  const { data, isLoading, error } = useGetMealEntriesById({ foodEntryId });

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Something went wrong: {error.message}</div>;
  }

  return <EditMealFoodEntryForm data={data} />;
}
