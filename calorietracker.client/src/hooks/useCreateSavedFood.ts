import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { CreateSavedFoodDto } from "@/utils/types.ts";

export function useCreateSavedFood() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (payload: CreateSavedFoodDto) => axios.post("/api/saved-food", payload),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["saved-foods"]
      });
    }
  });
}