import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { SavedFoods } from "@/utils/types.ts";

export function useGetSavedFoods() {
  return useQuery({
    queryKey: ["saved-foods"],
    queryFn: async () => {
      const response = await axios.get("/api/saved-foods");
      const data: SavedFoods = response.data;
      return data;
    }
  });
}