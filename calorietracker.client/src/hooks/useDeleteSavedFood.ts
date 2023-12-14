import { useMutation, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

export function useDeleteSavedFood() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (foodDiaryEntryId: number) =>
      axios.delete(`/api/saved-food/${foodDiaryEntryId}`),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["saved-foods"]
      });
    }
  });
}
