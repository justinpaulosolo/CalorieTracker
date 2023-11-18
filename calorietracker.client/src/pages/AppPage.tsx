import FoodEntryForm from "@/components/food-entry-form";
import MealEntry from "@/components/meal-entries";
import TotalMacros from "@/components/total-macros";

function AppPage() {
  const mealTypes = ["Breakfast", "Lunch", "Dinner", "Other"];
  return (
    <div className="fle flex-col space-y-4">
      <FoodEntryForm />
      <TotalMacros />
      {mealTypes.map(mealType => (
        <MealEntry key={mealType} mealType={mealType} />
      ))}
    </div>
  );
}

export default AppPage;
