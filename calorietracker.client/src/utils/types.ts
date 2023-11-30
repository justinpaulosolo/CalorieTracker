export type Register = {
  username: string;
  email: string;
  password: string;
};

export type Login = {
  username: string;
  password: string;
};

export type User = {
  userId: string;
  username: string;
  email: string;
};

export type Diary = {
  diaryId: number;
  userId: string;
  date: string;
  foodDiaries: FoodDiary[];
};

export type Food = {
  foodId: number;
  foodDiaryEntryId: number;
  name: string;
  protein: number;
  carbs: number;
  fat: number;
  calories: number;
};

export type FoodDiary = {
  foodDiaryId: number;
  diaryId: number;
  mealTypeId: number;
  foods: Food[];
};

export type CreateMealEntry = {
  mealType: string;
  date: string;
  foodName: string;
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

export type EditMealEntry = {
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
