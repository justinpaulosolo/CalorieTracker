import { Navigate, Route, Routes } from "react-router-dom";
import Login from "./pages/LoginPage";
import Register from "./pages/RegisterPage";
import PrivateRoute from "./components/private-route";
import SettingsLayout from "./components/settings/settings-layout";
import AccountSettingsPage from "./pages/settings/AccountSettingsPage";
import GoalSettingsPage from "./pages/settings/GoalSettingsPage";
import FoodDiaryDashboard from "@/pages/FoodDiaryDashboard.tsx";
import DetailedFoodDiaryPage from "@/pages/DetailedFoodDiaryPage.tsx";
import NewFoodDiaryEntryPage from "@/pages/NewFoodDiaryEntryPage.tsx";

function App() {
  return (
    <Routes>
      <Route path="/register" element={<Register />} />
      <Route path="/login" element={<Login />} />
      <Route element={<PrivateRoute />}>
        <Route path="/" element={<Navigate to="/food-diary" replace />} />
        <Route path="/food-diary" element={<FoodDiaryDashboard />} />
        <Route
          path="/food-diary/detailed"
          element={<DetailedFoodDiaryPage />}
        />
        <Route
          path="/food-diary/detailed/new/:date/:meal"
          element={<NewFoodDiaryEntryPage />}
        />
        <Route path="/settings" element={<SettingsLayout />}>
          <Route path="/settings/goals" element={<GoalSettingsPage />} />
          <Route path="/settings/account" element={<AccountSettingsPage />} />
        </Route>
      </Route>
    </Routes>
  );
}

export default App;
