export type CreateMealEntry = {
    mealType: string,
    date:  string,
    name: string,
    proteins: number,
    carbs: number,
    fats: number,
    calories: number,
    quantity: number,
}

export type MealEntriesType = {
    calories: string,
    carbs: string,
    fats: string,
    foodEntryId: number,
    foodId: string,
    mealId: string,
    foodName: string
    proteins: string
}