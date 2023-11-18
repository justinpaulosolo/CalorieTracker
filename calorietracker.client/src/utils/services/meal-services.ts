import axios from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { CreateMealEntry } from "../types";
import useCurrentDate from "../hooks/useCurrentDate";

interface DeleteMealEntryVariables {
  id: number;
  date: string;
  mealType: string;
}

interface CreateMealEntryVariables {
  mealEntry: CreateMealEntry;
  mealType: string;
}

export function useDeleteMealEntry() {
  const queryClient = useQueryClient();
  return useMutation<void, unknown, DeleteMealEntryVariables>({
    mutationFn: async ({ id }: { id: number }) => {
      const response = await axios.delete(`/api/meal-entries/${id}`);
      return response.data;
    },
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({
        queryKey: ["meals", variables.date, variables.mealType],
      });
    },
  });
}

export function useGetMealEntriesByDateAndType({
  currentDate,
  mealType,
}: {
  currentDate: string;
  mealType: string;
}) {
  return useQuery({
    queryKey: ["meals", currentDate, mealType],
    queryFn: async () => {
      const response = await axios.get(
        `/api/meal-entries/${currentDate}/${mealType}`
      );
      const data = response.data;
      return data;
    },
  });
}

export function useCreateMealEntry() {
  const [currentDate] = useCurrentDate();
  const queryClient = useQueryClient();
  return useMutation<void, unknown, CreateMealEntryVariables>({
    mutationFn: ({ mealEntry }) => axios.post("/api/meal-entries", mealEntry),
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({
        queryKey: ["meals", currentDate, variables.mealType],
      });
    },
  });
}

export function useGetMealsTotalMacrosByDate({ date }: { date: string }) {
  return useQuery({
    queryKey: ["meals-total-macros", date],
    queryFn: async () => {
      const response = await axios.get(`/api/meals/${date}/total-macros`);
      const data = response.data;
      return data;
    },
  });
}
