import { Navigate, Route, Routes } from "react-router-dom";
import Login from "./pages/LoginPage";
import Register from "./pages/RegisterPage";
import PrivateRoute from "./components/private-route";
import SettingsLayout from "./components/settings/settings-layout";
import AccountSettingsPage from "./pages/settings/AccountSettingsPage";
import NutritionGoalPage from "./pages/settings/NutritionGoalPage.tsx";
import FoodDiaryDashboard from "@/pages/FoodDiaryDashboard.tsx";
import DetailedFoodDiaryPage from "@/pages/DetailedFoodDiaryPage.tsx";
import UpdateMealEntryPage from "@/pages/UpdateMealEntryPage.tsx";
import SavedFoodPage from "@/pages/SavedFoodsPage.tsx";
import CreateSavedFoodPage from "@/pages/CreateSavedFoodPage.tsx";

function App() {
  return (
    <Routes>
      <Route path="/register" element={<Register />} />
      <Route path="/login" element={<Login />} />
      <Route element={<PrivateRoute />}>
        <Route path="/" element={<Navigate to="/food-diary" replace />} />
        <Route path="/food-diary" element={<FoodDiaryDashboard />} />
        <Route path="/food-diary/entry/:id" element={<UpdateMealEntryPage />} />
        <Route
          path="/food-diary/detailed"
          element={<DetailedFoodDiaryPage />}
        />
        <Route path="/saved-foods" element={<SavedFoodPage />} />
        <Route path="/saved-foods/new" element={<CreateSavedFoodPage />} />
        <Route path="/settings" element={<SettingsLayout />}>
          <Route path="/settings/nutritional-goal" element={<NutritionGoalPage />} />
          <Route path="/settings/account" element={<AccountSettingsPage />} />
        </Route>
      </Route>
    </Routes>
  );
}

export default App;
