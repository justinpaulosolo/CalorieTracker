import axios from "axios";
import { useMutation, useQuery } from "@tanstack/react-query";
import { CreateMealEntry } from "../types";

type fetchMealEntryByDateMealProps = {
    date: string,
    mealType: string
};

async function fetchMealEntryByDateMeal(props: fetchMealEntryByDateMealProps) {
    const response = await axios.get(`/api/meal-entries/${props.mealType}/${props.date}`);
    const data = response.data;
    return data;
}

export function useBreakfastMealEnties({date}: {date: string}) {
    const props = {
        date: date,
        mealType: 'Breakfast'
    }
    return useQuery({
        queryKey: ['breakfast-meal-entries', props],
        queryFn: () => fetchMealEntryByDateMeal(props)
    })
}

export function useLunchMealEnties({date}: {date: string}) {
    const props = {
        date: date,
        mealType: 'Lunch'
    }
    return useQuery({
        queryKey: ['lunch-meal-entries', props],
        queryFn: () => fetchMealEntryByDateMeal(props)
    })
}
export function useDinnerMealEnties({date}: {date: string}) {
    const props = {
        date: date,
        mealType: 'Dinner'
    }
    return useQuery({
        queryKey: ['dinner-meal-entries', props],
        queryFn: () => fetchMealEntryByDateMeal(props)
    })
}


export function useCreateMealEntry() {
    return useMutation({
        mutationFn: (mealEntry: CreateMealEntry) =>
        axios.post('/api/meal-entries', mealEntry)
    })
}

