import BreakfastMealEntries from "@/components/breakfast-meal-entries";
import DinnerMealEntries from "@/components/dinner-meal-entries";
import FoodEntryForm from "@/components/food-entry-form";
import LunchMealEntries from "@/components/lunch-meal-entries";
import { useState } from "react";

function AppPage() {
    const [date] = useState(new Date().toISOString());
    return (
        <div className="fle flex-col space-y-4">
            <FoodEntryForm />
            <BreakfastMealEntries date={date} />
            <LunchMealEntries date={date} />
            <DinnerMealEntries date={date} />
        </div>
    );
}

export default AppPage;