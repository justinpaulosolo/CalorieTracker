import axios from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { CreateMealEntry } from "../types";

interface DeleteMealEntryVariables {
  id: number;
  date: string;
  mealType: string;
}

interface CreateMealEntryVariables {
  mealEntry: CreateMealEntry;
  date: string;
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
  date,
  mealType,
}: {
  date: string;
  mealType: string;
}) {
  return useQuery({
    queryKey: ["meals", date, mealType],
    queryFn: async () => {
      const response = await axios.get(`/api/meal-entries/${date}/${mealType}`);
      const data = response.data;
      return data;
    },
  });
}

export function useCreateMealEntry() {
  const queryClient = useQueryClient();
  return useMutation<void, unknown, CreateMealEntryVariables>({
    mutationFn: ({ mealEntry }) => axios.post("/api/meal-entries", mealEntry),
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({
        queryKey: ["meals", variables.date, variables.mealType],
      });
    },
  });
}
