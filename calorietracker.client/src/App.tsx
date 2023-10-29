import { Route, Routes } from "react-router-dom";
import Login from "./pages/Login";
import Register from "./pages/Register";
import AppPage from "./pages/AppPage";
import PrivateRoute from "./components/private-route";

function App() {
  return (
    <Routes>
      <Route path="/login" element={<Login />} />
      <Route path="/register" element={<Register />} />
      <Route element={<PrivateRoute />}>
        <Route path="/" element={<AppPage />} />
      </Route>
    </Routes>
  );
}

export default App;
