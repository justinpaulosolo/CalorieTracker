import axios from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { CreateMealEntry } from "../types";

const fetchMeals = async ({date, mealType} : {date: string, mealType: string}) => {
    const response =await axios.get(`/api/meal-entries/${date}/${mealType}`);
    return response.data;
}

const deleteMealEntry = async (id: number) => {
    const response = await axios.delete(`/api/meal-entries/${id}`);
    return response.data;
}

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
      mutationFn: ({ id }) => deleteMealEntry(id),
      onSuccess: (_, variables) => {
        queryClient.invalidateQueries({
          queryKey: ['meals', variables.date, variables.mealType]
        });
      }
    });
  }

export function useFetchMealEntryByDateMeal({date, mealType} : {date: string, mealType: string}) {
    return useQuery({ queryKey: ['meals', date, mealType], queryFn: ()=> fetchMeals({date, mealType})});
}


export function useCreateMealEntry() {
    const queryClient = useQueryClient();
    return useMutation<void, unknown, CreateMealEntryVariables>({
      mutationFn: ({ mealEntry }) => axios.post('/api/meal-entries', mealEntry),
      onSuccess: (_, variables) => {
        queryClient.invalidateQueries({
          queryKey: ['meals', variables.date, variables.mealType]
        });
      }
    });
  }

