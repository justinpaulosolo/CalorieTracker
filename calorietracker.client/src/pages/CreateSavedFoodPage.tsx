import CreateSavedFoodForm from "@/components/saved-foods/create-saved-food-form.tsx";
import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card.tsx";

export default function CreateSavedFoodPage() {
  return (
    <div className="flex flex-col space-y-4">
      <Card className="mx-auto w-3/6">
        <CardHeader>
          <CardTitle>Create Saved Food</CardTitle>
        </CardHeader>
        <CardContent>
          <CreateSavedFoodForm />
        </CardContent>
      </Card>
    </div>
  );
}