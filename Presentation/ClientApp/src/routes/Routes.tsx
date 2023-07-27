import { Routes, Route } from "react-router-dom";
import ProtectedRoutes from "./ProtectetRoutes";
import Layout from "../components/layout/Layout";
import NotFound from "../features/error/NotFound";
import Login from "../features/authentication/Login";
import Home from "../features/home/Home";
import View from "../features/box/View";
import Upload from "../features/box/Upload";
import Register from "../features/authentication/Register";
import User from "../features/user/User.tsx";

const AppRoutes = ()=>{
    return (
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route element={<ProtectedRoutes ><Layout /></ProtectedRoutes>} >
                <Route element={<Home />} path="/"  />
                <Route element={<View />} path="/box/view/:id" />
                <Route element={<Upload />} path="/box/upload" />
                <Route element={<User />} path="/user" />
            </Route>
            <Route path="*" element={<NotFound />} />
        </Routes>
    )
}

export default AppRoutes;