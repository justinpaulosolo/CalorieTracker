import {
  Card,
  CardContent,
  CardHeader,
  CardTitle,
} from "@/components/ui/card.tsx";
import { Beef, Croissant, EggFried, Flame } from "lucide-react";
import { useGetNutritionInfo } from "@/hooks/useGetNutritionInfo.ts";
import { Icons } from "@/components/icons.tsx";
import { format } from "date-fns";

export function NutritionInfoCard({ date }: { date: Date }) {
  const { data: NutritionInfo, isLoading } = useGetNutritionInfo(
    format(date, "yyyy-MM-dd"),
  );
  return (
    <>
      <Card>
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium">Calories</CardTitle>
          <Flame className="h-4 w-4 text-muted-foreground" />
        </CardHeader>
        <CardContent className="flex justify-center">
          <div className="text-2xl font-medium">
            {isLoading ? (
              <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
            ) : (
              NutritionInfo?.calories
            )}
            <span className="text-lg text-muted-foreground">kcal</span>
          </div>
        </CardContent>
      </Card>
      <Card>
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium">Protein</CardTitle>
          <Beef className="h-4 w-4 text-muted-foreground" />
        </CardHeader>
        <CardContent className="flex justify-center">
          <div className="text-2xl font-medium">
            {isLoading ? (
              <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
            ) : (
              NutritionInfo?.protein
            )}
            <span className="text-lg text-muted-foreground">g</span>
          </div>
        </CardContent>
      </Card>
      <Card>
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium">Carbs</CardTitle>
          <Croissant className="h-4 w-4 text-muted-foreground" />
        </CardHeader>
        <CardContent className="flex justify-center">
          <div className="text-2xl font-medium">
            {isLoading ? (
              <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
            ) : (
              NutritionInfo?.carbs
            )}
            <span className="text-lg text-muted-foreground">g</span>
          </div>
        </CardContent>
      </Card>
      <Card>
        <CardHeader className="flex flex-row items-center justify-between space-y-0 pb-2">
          <CardTitle className="text-sm font-medium">Fat</CardTitle>
          <EggFried className="h-4 w-4 text-muted-foreground" />
        </CardHeader>
        <CardContent className="flex justify-center">
          <div className="text-2xl font-medium">
            {isLoading ? (
              <Icons.spinner className="mr-2 h-4 w-4 animate-spin" />
            ) : (
              NutritionInfo?.fat
            )}
            <span className="text-lg text-muted-foreground">g</span>
          </div>
        </CardContent>
      </Card>
    </>
  );
}

export default NutritionInfoCard;
