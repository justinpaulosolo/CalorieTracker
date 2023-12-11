import axios from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { CreateMealEntry, EditMealEntry } from "../types";

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
      const response = await axios.delete(`/api/meals/${id}`);
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
      const response = await axios.get(`/api/meals/${currentDate}/${mealType}`);
      const data = response.data;
      return data;
    },
  });
}

export function useCreateMealEntry() {
  const queryClient = useQueryClient();
  return useMutation<void, unknown, CreateMealEntryVariables>({
    mutationFn: ({ mealEntry }) => axios.post("/api/meals", mealEntry),
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({
        queryKey: ["meals", variables.mealEntry.date, variables.mealType],
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

export function useEditMealEntry() {
  const queryClient = useQueryClient();
  return useMutation<void, unknown, EditMealEntry>({
    mutationFn: async ({ foodMealEntryId, ...mealEntry }) => {
      const response = await axios.put(
        `/api/meals/edit/${foodMealEntryId}`,
        mealEntry,
      );
      return response.data;
    },
    onSuccess: (_, variables) => {
      queryClient.invalidateQueries({
        queryKey: ["meals", variables.date, variables.mealType],
      });
    },
  });
}
