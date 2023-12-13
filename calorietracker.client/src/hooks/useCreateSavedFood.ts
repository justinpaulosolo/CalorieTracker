import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { SavedFood } from "@/utils/types.ts";

export function useCreateSavedFood() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (payload: SavedFood) => axios.post("/api/saved-food", payload),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["saved-food"]
      });
    }
  });
}