import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { NutritionGoal } from "@/utils/types.ts";

export function useGetNutritionGoal() {
  return useQuery({
    queryKey: ["nutrition-goal"],
    queryFn: async () => {
      const response = await axios.get("/api/nutrition-goal");
      const data: NutritionGoal = response.data;
      return data;
    }
  });
}
