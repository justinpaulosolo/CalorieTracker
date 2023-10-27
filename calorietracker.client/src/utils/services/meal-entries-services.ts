import axios from "axios";
import { useMutation, useQuery, useQueryClient } from "@tanstack/react-query";
import { CreateMealEntry } from "../types";

const fetchMeals = async ({date, mealType} : {date: string, mealType: string}) => {
    const response =await axios.get(`/api/meal-entries/${mealType}/${date}`);
    return response.data;
}

const deleteMealEntry = async (id: number) => {
    const response = await axios.delete(`/api/meal-entries/${id}`);
    return response.data;
}

export function useDeleteMealEntry() {
    const queryClient = useQueryClient();
    return useMutation({
        mutationFn: (id: number) => deleteMealEntry(id),
        onSettled: () => {
            queryClient.invalidateQueries({
                queryKey: ['meals']
            })
        }
    })
}

export function useFetchMealEntryByDateMeal({date, mealType} : {date: string, mealType: string}) {
    return useQuery({ queryKey: ['meals', date, mealType], queryFn: ()=> fetchMeals({date, mealType})});
}


export function useCreateMealEntry() {
    const queryClient = useQueryClient();
    return useMutation({
        mutationFn: (mealEntry: CreateMealEntry) =>
        axios.post('/api/meal-entries', mealEntry),
        onSettled: (data, error, variables) => {
            queryClient.invalidateQueries({
                queryKey: ['meals', variables.date, variables.mealType]
            })
        }
    })
}

