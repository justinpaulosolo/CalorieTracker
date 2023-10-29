import {
  Card,
  CardDescription,
  CardHeader,
  CardTitle,
} from "@/components/ui/card";
import { useGetMealsTotalMacrosByDate } from "@/utils/services/meal-services";

function TotalMacros({ currentDate }: { currentDate: string }) {
  const { data, isLoading, error } = useGetMealsTotalMacrosByDate({
    date: currentDate,
  });

  if (isLoading) {
    return <div className="flex items-center space-x-4">Loading...</div>;
  }

  if (error) {
    return <span>Error: {error.message}</span>;
  }

  return (
    <div className="flex flex-row justify-between space-x-10">
      <Card className="w-full">
        <CardHeader>
          <CardTitle className="text-center">Proteins</CardTitle>
          <CardDescription className="text-center">
            {data.totalProteins}
          </CardDescription>
        </CardHeader>
      </Card>
      <Card className="w-full">
        <CardHeader>
          <CardTitle className="text-center">Carbs</CardTitle>
          <CardDescription className="text-center">
            {data.totalCarbs}
          </CardDescription>
        </CardHeader>
      </Card>
      <Card className="w-full">
        <CardHeader>
          <CardTitle className="text-center">Fats</CardTitle>
          <CardDescription className="text-center">
            {data.totalFats}
          </CardDescription>
        </CardHeader>
      </Card>
      <Card className="w-full">
        <CardHeader>
          <CardTitle className="text-center">Calories</CardTitle>
          <CardDescription className="text-center">
            {data.totalCalories}
          </CardDescription>
        </CardHeader>
      </Card>
    </div>
  );
}

export default TotalMacros;
