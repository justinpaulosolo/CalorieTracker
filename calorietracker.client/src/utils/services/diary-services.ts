import { useQuery } from "@tanstack/react-query";
import axios from "axios";
import { Diary } from "../types";
import { useMemo } from "react";

export function useGetFoodDiaryByDate(date: string) {
  const queryInfo = useQuery({
    queryKey: ["food-diary", date],
    queryFn: async () => {
      const response = await axios.get(`/api/diary/${date}/food`);
      const data: Diary = response.data;
      return data;
    },
  });

  return {
    ...queryInfo,
    breakfast: useMemo(
      () => queryInfo.data?.foodDiaries.find(diary => diary.mealTypeId === 1),
      [queryInfo.data]
    ),
    lunch: useMemo(
      () => queryInfo.data?.foodDiaries.find(diary => diary.mealTypeId === 2),
      [queryInfo.data]
    ),
    dinner: useMemo(
      () => queryInfo.data?.foodDiaries.find(diary => diary.mealTypeId === 3),
      [queryInfo.data]
    ),
    snacks: useMemo(
      () => queryInfo.data?.foodDiaries.find(diary => diary.mealTypeId === 4),
      [queryInfo.data]
    ),
  };
}
