import { Navigate } from "react-router-dom";
import { AppStorage } from "../assets/utilities/storage";
import store from "../store";
import { boxApi } from "../features/box/boxApi";

type props = {
    children: JSX.Element
}
const ProtectedRoutes = ({children} : props)=>{
    const isAuthenticated = AppStorage.Provider.getItem("token") ?? '';
    if (!isAuthenticated)
        return (<Navigate to="/login" />);
    
    store.dispatch(boxApi.endpoints.getAllFiles.initiate());

    return (children);
}

export default ProtectedRoutes;