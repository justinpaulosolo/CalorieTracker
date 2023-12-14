import { useMutation, useQueryClient } from "@tanstack/react-query";
import { CreateNutritionGoalDto } from "@/utils/types.ts";
import axios from "axios";

export function useCreateNutritionGoal() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (payload: CreateNutritionGoalDto) => axios.post("/api/nutrition-goal", payload),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["nutrition-goal"]
      });
    }
  });
}