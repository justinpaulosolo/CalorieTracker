import FoodEntryForm from "@/components/food-entry-form";
import MealEntry from "@/components/meal-entries";
import TotalMacros from "@/components/total-macros";
import { useState } from "react";

function AppPage() {
  const [date] = useState<string>(() => {
    const now = new Date();
    const timezoneOffset = now.getTimezoneOffset() * 60000;
    return new Date(now.getTime() - timezoneOffset).toISOString().slice(0, -1);
  });
  const mealTypes = ["Breakfast", "Lunch", "Dinner", "Other"];
  return (
    <div className="fle flex-col space-y-4">
      <FoodEntryForm currentDate={date} />
      <TotalMacros currentDate={date} />
      {mealTypes.map(mealType => (
        <MealEntry key={mealType} date={date} mealType={mealType} />
      ))}
    </div>
  );
}

export default AppPage;
