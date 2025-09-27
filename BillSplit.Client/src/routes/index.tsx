import { BrowserRouter, Routes, Route, Navigate, Outlet } from "react-router-dom";
import Register from "../pages/auth/register"
import Login from "../pages/auth/login";
import {Homepage} from "../pages/Homepage/Homepage.tsx";
import AppLayout from "../layouts/AppLayout.tsx";
import MainGrid from "../components/MainGrid.tsx";
import Friends from "../pages/Friends/Friends.tsx";
import {Trips} from "../pages/Trips/Trips.tsx";
import { Analytics } from "../pages/Analytics/Analytics.tsx";
import { Settings } from "../pages/Settings/Settings.tsx";
// ✅ Simple auth check (using localStorage instead of Redux)
export  function PrivateRoute() {
    const token = localStorage.getItem("token");
    return token ? <Outlet /> : <Navigate to="/auth/login" replace />;
}
export default function AppRoutes() {
    
  return (
      <BrowserRouter>
          <Routes>
              {/* Public routes */}
              <Route path="/" element={<Homepage />} />
              <Route path="auth">
                  <Route index element={<Navigate to="login" replace />} />
                  <Route path="login" element={<Login />} />
                  <Route path="register" element={<Register />} />
              </Route>
              {/* Protected routes */}
              <Route element={<PrivateRoute />}>
                  <Route element={<AppLayout />}>
                      <Route path="dashboard" element={<MainGrid />} />
                      <Route path="friends" element={<Friends />} />
                      <Route path="trips" element={<Trips />} />
                      <Route path="analytics" element={<Analytics />} />
                      <Route path="settings" element={<Settings />} />
                  </Route>
              </Route>

              {/* Catch-all */}
              <Route path="*" element={<Navigate to="/" replace />} />
          </Routes>
      </BrowserRouter>
  );
}
