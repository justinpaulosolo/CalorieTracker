import axios from "axios";
import { useMutation } from "@tanstack/react-query";
import { CreateMealEntry } from "../types";

export function useCreateMealEntry() {
    return useMutation({
        mutationFn: (mealEntry: CreateMealEntry) =>
        axios.post('/api/meal-entries', mealEntry)
    })
}