import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { GetDiaryFoodsResponse } from "@/utils/types.ts";

export function useGetDiaryFoods(date: string) {
  return useQuery({
    queryKey: ["diary-foods", date],
    queryFn: async () => {
      const response = await axios.get(`/api/diary/foods/${date}`);
      const data: GetDiaryFoodsResponse = response.data;
      return data;
    },
  });
}
