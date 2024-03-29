import * as z from "zod";
import { accountSettingsSchema, loginFormSchema, registerFormSchema } from "@/utils/schemas.ts";

export type RegisterUser = z.infer<typeof registerFormSchema>;

export type LoginUser = z.infer<typeof loginFormSchema>;

export type UpdateAccount = z.infer<typeof accountSettingsSchema>;

export type User = {
  userId: string;
  userName: string;
  email: string;
};

export type Diary = {
  diaryId: number;
  userId: string;
  date: string;
  foodDiaries: FoodDiary[];
};

export type FoodDiaryEntry = {
  date: string;
  meal?: string;
  foodId: number;
  foodDiaryEntryId?: number;
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
  foods: FoodDiaryEntry[];
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

export type MealTypes = "Breakfast" | "Lunch" | "Dinner" | "Snacks";

export type Nutrition = {
  calories: number;
  protein: number;
  carbs: number;
  fat: number;
};

export type GetDiaryFoodsResponse = {
  data: FoodDiaryEntry[];
};

export type UpdateFoodDiaryEntryDto = {
  meal: string;
  date: string;
  name: string;
  protein: number;
  carbs: number;
  fat: number;
  calories: number;
};

export type SavedFood = {
  savedFoodId: number;
  name: string;
  protein: number;
  carbs: number;
  fat: number;
  calories: number;
}

export type SavedFoods = {
  savedFoods: SavedFood[];
}

export type CreateSavedFoodDto = {
  name: string;
  protein: number;
  carbs: number;
  fat: number;
  calories: number;
}

export type NutritionGoal = {
  nutritionGoalId: number;
  calories: number;
  protein: number;
  carbs: number;
  fat: number;
}

export type CreateNutritionGoalDto = {
  calories: number;
  protein: number;
  carbs: number;
  fat: number;
}

export type UpdateNutritionGoalDto = {
  nutritionGoalId: number;
  calories: number;
  protein: number;
  carbs: number;
  fat: number;
}

export type UpdateAccountDto = {
  email: string,
  username: string,
}
