import { Link, useNavigate } from "react-router-dom";
import { Outlet } from "react-router-dom";
import { AppStorage } from "../../assets/utilities/storage";
import { useDispatch } from "react-redux";
import { boxApi } from "../../features/box/boxApi";

const Layout = ()=>{
    const navigator = useNavigate();
    const dispatch = useDispatch();
    const logout = ()=>{
        AppStorage.Provider.clear();
        dispatch(boxApi.util.resetApiState());
        navigator("/login");
    }
    return (
        <div>
            <header className="bg-gray-200 p-5 mb-5 shadow-xl">
                <nav className="ml-3">
                    <ul className="flex gap-10">
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li className="absolute right-8">
                            <button onClick={logout}>Logout</button>
                        </li>
                    </ul>
                </nav>
            </header>
            <div className="flex flex-col">
                <div className="mx-5">
                    <Outlet />
                </div>
            </div>
        </div>
    )
}

export default Layout;