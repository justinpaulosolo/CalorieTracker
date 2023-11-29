import EditMealEntryForm from "@/components/edit-meal-entry-form";
import { useGetMealEntriesById } from "@/utils/services/meal-services";
import { useParams } from "react-router-dom";

export default function EditMealEntryPage() {
  const { id } = useParams();
  const foodEntryId = Number(id);
  const { data, isLoading, error } = useGetMealEntriesById({ foodEntryId });

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Something went wrong: {error.message}</div>;
  }

  return <EditMealEntryForm mealEntry={data} />;
}
