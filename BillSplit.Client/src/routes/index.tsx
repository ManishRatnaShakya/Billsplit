import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Register from "../pages/auth/register"
import type { JSX } from "react";
import Login from "../pages/auth/login";
import {AppLayout} from "../layouts/AppLayout.tsx";
import {Homepage} from "../pages/Homepage/Homepage.tsx";

// ✅ Simple auth check (using localStorage instead of Redux)
function PrivateRoute({ children }: { children: JSX.Element }) {
  const token = localStorage.getItem("token");
  return token ? children : <Navigate to="/auth/login" replace />;
}

export default function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        {/* auth routes */}
          
       <Route path="/" element={<Homepage />} />
          
       <Route path="auth">
            <Route index element={<Navigate to="login" replace />} />
            <Route path="login" element={<Login />} />
            <Route path="register" element={<Register />} />
        </Route>

        {/* Protected dashboard */}
        <Route
          path="dashboard"
          element={
            <PrivateRoute>
               <AppLayout/>
            </PrivateRoute>
          }
        />
        {/* Default redirect */}
        <Route path="*" element={<Navigate to="/" replace />} />
      </Routes>
    </BrowserRouter>
  );
}
