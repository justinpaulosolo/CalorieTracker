import { Separator } from "@/components/ui/separator.tsx";
import NutritionGoalForm from "@/components/settings/forms/nutrition-goal-form.tsx";

export default function NutritionGoalPage() {
  return (
    <div className="flex flex-col space-y-6">
      <div>
        <h3 className="text-lg font-medium">Nutritional Goal</h3>
        <p className="text-sm text-muted-foreground">
          Set your daily nutritional goals, and we'll help you stay on track.
        </p>
      </div>
      <Separator />
      <NutritionGoalForm />
    </div>
  );
}
