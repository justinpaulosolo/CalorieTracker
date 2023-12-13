import { useParams } from "react-router-dom";
import { useGetFoodDiaryEntryById } from "@/hooks/useGetFoodDiaryEntryById.ts";
import UpdateFoodDiaryEntryForm from "@/components/food-diary/forms/update-food-diary-entry-form.tsx";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card.tsx";

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
    <div className="flex flex-col space-y-4">
      <Card className="mx-auto w-3/6">
        <CardHeader>
          <CardTitle>Update Food Diary Entry</CardTitle>
        </CardHeader>
        <CardContent>
          <UpdateFoodDiaryEntryForm foodDiaryEntry={data!} />
        </CardContent>
      </Card>
    </div>
  );
}
