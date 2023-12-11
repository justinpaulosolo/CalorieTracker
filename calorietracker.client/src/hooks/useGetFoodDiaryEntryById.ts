import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { FoodDiaryEntry } from "@/utils/types.ts";

export function useGetFoodDiaryEntryById(id: number) {
  return useQuery({
    queryKey: ["food-diary-entry", id],
    queryFn: async () => {
      const response = await axios.get(`/api/diary/food/${id}`);
      const data: FoodDiaryEntry = response.data;
      return data;
    }
  });
}
