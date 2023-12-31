import { FoodQuickAddFormValues } from "@/components/food-diary/forms/food-diary-entry-quick-add-form.tsx";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

export function useCreateFoodDiaryEntry() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (foodDiaryEntry: FoodQuickAddFormValues) =>
      axios.post("/api/diary/food", foodDiaryEntry),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["food-diary"]
      });
    }
  });
}

export function useGetFoodDiaryByDate(date: string) {
  return useQuery({
    queryKey: ["food-diary", date],
    queryFn: () => axios.get(`/api/diary/food/${date}`)
  });
}

export function useDeleteFoodDiaryEntry() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (foodDiaryEntryId: number) =>
      axios.delete(`/api/diary/food/${foodDiaryEntryId}`),
    onSuccess: () => {
      return queryClient.invalidateQueries({
        queryKey: ["food-diary"]
      });
    }
  });
}
