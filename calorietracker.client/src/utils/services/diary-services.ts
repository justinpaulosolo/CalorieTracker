import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import axios from "axios";
import { Diary } from "../types";
import { useMemo } from "react";

const MEAL_TYPE_IDS = {
  BREAKFAST: 1,
  LUNCH: 2,
  DINNER: 3,
  SNACKS: 4,
};

export interface CreateFoodDiaryEntryDto {
  foodName: string;
  protein: number;
  carbs: number;
  fat: number;
  calories: number;
  meal: string;
  date: string;
}

export function useCreateFoodDiaryEntry(date: string) {
  const queryClient = useQueryClient();
  console.log(date, "service");
  return useMutation({
    mutationFn: (foodDiaryEntry: CreateFoodDiaryEntryDto) =>
      axios.post("/api/diary/food", foodDiaryEntry),
    onSuccess: () =>
      Promise.all([
        queryClient.invalidateQueries({
          queryKey: ["diary-foods", date],
        }),
        queryClient.invalidateQueries({
          queryKey: ["nutrition", date],
        }),
      ]),
  });
}

export function useGetFoodDiaryByDate(date: string) {
  const queryInfo = useQuery({
    queryKey: ["food-diary", date],
    queryFn: async () => {
      await new Promise(resolve => setTimeout(resolve, 500));
      const response = await axios.get(`/api/diary/${date}/food`);
      const data: Diary = response.data;
      return data;
    },
    retry: false,
  });
  return {
    isLoading: queryInfo.isLoading,
    breakfast: useMemo(
      () =>
        queryInfo.data?.foodDiaries.find(
          diary => diary.mealTypeId === MEAL_TYPE_IDS.BREAKFAST,
        ),
      [queryInfo.data],
    ),
    lunch: useMemo(
      () =>
        queryInfo.data?.foodDiaries.find(
          diary => diary.mealTypeId === MEAL_TYPE_IDS.LUNCH,
        ),
      [queryInfo.data],
    ),
    dinner: useMemo(
      () =>
        queryInfo.data?.foodDiaries.find(
          diary => diary.mealTypeId === MEAL_TYPE_IDS.DINNER,
        ),
      [queryInfo.data],
    ),
    snacks: useMemo(
      () =>
        queryInfo.data?.foodDiaries.find(
          diary => diary.mealTypeId === MEAL_TYPE_IDS.SNACKS,
        ),
      [queryInfo.data],
    ),
  };
}
