import { Navigate } from "react-router-dom";
import { AppStorage } from "../assets/utilities/storage";

type props = {
    children: JSX.Element
}
const ProtectedRoutes = ({children} : props)=>{
    const isAuthenticated = AppStorage.Provider.getItem("token") ?? '';

    if(isAuthenticated)
        return (children);

    return (<Navigate to="/login" />)
}

export default ProtectedRoutes;