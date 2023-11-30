import { FoodQuickAddFormValues } from "@/pages/food/forms/food-quick-add-form";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";

export function useCreateFoodDiaryEntry() {
  const queryClient = useQueryClient();
  return useMutation({
    mutationFn: (foodDiaryEntry: FoodQuickAddFormValues) =>
      axios.post("/api/diary/food", foodDiaryEntry),
    onSuccess: () => {
      queryClient.invalidateQueries({
        queryKey: ["food-diary"],
      });
    },
  });
}

export function useGetFoodDiaryByDate(date: string) {
  return useQuery({
    queryKey: ["food-diary", date],
    queryFn: () => axios.get(`/api/diary/food/${date}`),
  });
}