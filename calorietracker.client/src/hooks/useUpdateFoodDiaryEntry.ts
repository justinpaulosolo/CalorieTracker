import { useMutation, useQueryClient } from "@tanstack/react-query";
import { UpdateFoodDiaryEntryDto } from "@/utils/types.ts";
import axios from "axios";

export function useUpdateFoodDiaryEntry(foodDiaryEntryId: number) {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (foodDiaryEntry: UpdateFoodDiaryEntryDto) =>
      axios.put(`/api/diary/food/edit/${foodDiaryEntryId}`, foodDiaryEntry),
    onSuccess: () => {
      Promise.all([
        queryClient.invalidateQueries({
          queryKey: ["food-diary-entry", foodDiaryEntryId]
        })
      ]);
    }
  });
}
