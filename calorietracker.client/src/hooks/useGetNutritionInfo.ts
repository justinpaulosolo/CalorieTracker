import axios from "axios";
import { useQuery } from "@tanstack/react-query";
import { Nutrition } from "@/utils/types.ts";

export function useGetNutritionInfo(date: string) {
  return useQuery({
    queryKey: ["nutrition", date],
    queryFn: async () => {
      const response = await axios.get(`/api/nutrition/${date}`);
      const data: Nutrition = response.data;
      return data;
    },
  });
}
