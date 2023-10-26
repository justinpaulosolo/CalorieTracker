export type CreateMealEntry = {
    userId: string,
    mealType: string,
    date:  string,
    name: string,
    proteins: number,
    carbs: number,
    fats: number,
    calories: number,
    quantity: number,
}

export type MealEntries = {
    calories: string,
    carbs: string,
    fats: string,
    foodEntryId: string,
    foodId: string,
    mealId: string,
    name: string
    proteins: string
}