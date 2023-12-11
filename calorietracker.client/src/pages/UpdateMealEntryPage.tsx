import { useParams } from "react-router-dom";
import { useGetFoodDiaryEntryById } from "@/hooks/useGetFoodDiaryEntryById.ts";
import UpdateFoodDiaryEntryForm from "@/components/food-diary/forms/update-food-diary-entry-form.tsx";

export default function UpdateMealEntryPage() {
  const { id } = useParams();
  const foodEntryId = Number(id);
  const { data, isLoading, error } = useGetFoodDiaryEntryById(foodEntryId);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Something went wrong: {error.message}</div>;
  }

  return (
    <UpdateFoodDiaryEntryForm foodDiaryEntry={data!} />
  );
}
