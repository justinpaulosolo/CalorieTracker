export type CreateMealEntry = {
  mealType: string;
  date: string;
  name: string;
  proteins: number;
  carbohydrates: number;
  fats: number;
  calories: number;
  quantity: number;
};

export type MealEntryType = {
  mealType: string;
  calories: string;
  carbohydrates: string;
  fats: string;
  foodEntryId: number;
  foodId: string;
  mealId: string;
  foodName: string;
  proteins: string;
};

export type EditFoodEntry = {
  foodMealEntryId: number;
  mealType: string;
  foodName: string;
  proteins: number;
  carbohydrates: number;
  fats: number;
  calories: number;
  date: string;
};

export enum MealEntryTypeEnums {
  Breakfast = "Breakfast",
  Lunch = "Lunch",
  Dinner = "Dinner",
  Other = "Other",
}
