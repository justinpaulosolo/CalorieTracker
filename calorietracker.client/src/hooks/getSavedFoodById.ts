import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { SavedFood } from "@/utils/types.ts";

export function useGetSavedFoodById(id: string) {
  return useQuery({
    queryKey: ["saved-food", id],
    queryFn: async () => {
      const response = await axios.get(`/api/saved-food/${id}`);
      const data: SavedFood = response.data;
      return data;
    }
  });
}