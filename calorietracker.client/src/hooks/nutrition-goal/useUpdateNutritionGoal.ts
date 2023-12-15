import { useMutation, useQueryClient } from "@tanstack/react-query";
import { UpdateNutritionGoalDto } from "@/utils/types.ts";
import axios from "axios";

export function useUpdateNutritionGoal() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (payload: UpdateNutritionGoalDto) => axios.put("/api/nutrition-goal/update", payload),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["nutrition-goal"]
      });
    }
  });
}