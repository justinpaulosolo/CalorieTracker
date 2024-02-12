import { Card, CardContent, CardFooter, CardHeader, CardTitle } from "@/components/ui/card";
import { Link } from "react-router-dom";
import NewExerciseEntryPage from "./NewExerciseEntryPage";
import { useState } from "react";
import RecentFoodEntriesCard from "@/components/recent-food-entries-card";

function ExerciseDiaryDashboard () {
  const [date] = useState(new Date());
  return (
    <div className="flex flex-col space-y-4">
      <h1 className="font-bold text-2xl">Exercise Diary Dashboard</h1>
      <div className="grid gap-4 grid-cols-6 items-start">
        <Card className="col-span-3">
          <CardHeader>
            <CardTitle>Add Exercise Entry</CardTitle>
          </CardHeader>
          <CardContent>
            <NewExerciseEntryPage date={date} />
          </CardContent>
        </Card>
        <Card className="col-span-3 p-0">
          <CardHeader>
            <CardTitle>Recent Food Diary Entries</CardTitle>
          </CardHeader>
          <CardContent className="p-3">
            <RecentFoodEntriesCard date={date} />
          </CardContent>
          <CardFooter className="mt-auto">
            <Link
              to="/food-diary/detailed"
              className="text-sm underline underline-offset-4"
            >
              View detailed food diary
            </Link>
          </CardFooter>
        </Card>
      </div>
    </div>
  )
}

export default ExerciseDiaryDashboard;
