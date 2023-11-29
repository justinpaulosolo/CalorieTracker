import { Route, Routes } from "react-router-dom";
import Login from "./pages/LoginPage";
import Register from "./pages/RegisterPage";
import AppPage from "./pages/AppPage";
import PrivateRoute from "./components/private-route";
import SettingsLayout from "./components/settings/settings-layout";
import AccountSettingsPage from "./pages/settings/AccountSettingsPage";
import GoalSettingsPage from "./pages/settings/GoalSettingsPage";
import EditMealEntryPage from "./pages/EditMealEntryPage";

function App() {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route element={<PrivateRoute />}>
        <Route path="/" element={<AppPage />} />
        <Route path="/food-entry/edit/:id" element={<EditMealEntryPage />} />
        <Route path="/settings" element={<SettingsLayout />}>
          <Route path="/settings/goals" element={<GoalSettingsPage />} />
          <Route path="/settings/account" element={<AccountSettingsPage />} />
        </Route>
      </Route>
    </Routes>
  );
}

export default App;
