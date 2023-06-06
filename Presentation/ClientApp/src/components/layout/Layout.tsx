import { Link } from "react-router-dom";
import { Outlet } from "react-router-dom";

const Layout = ()=>{

    return (
        <div>
            <header className="bg-gray-200 p-5 mb-5">
                <nav>
                    <ul className="flex gap-5">
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/box/upload">Upload</Link>
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