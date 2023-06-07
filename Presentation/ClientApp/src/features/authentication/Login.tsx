import { useLoginMutation } from "./loginApi";
import { useNavigate } from "react-router-dom";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";
import UserForm from "./components/UserForm";
import { Link } from "react-router-dom";
import toast from "react-hot-toast";

const Login = ()=>{
    const navigate = useNavigate();
    const [login, {error}] = useLoginMutation();
    const onSubmit = async (data: any) => {
        try {
            await toast.promise(login(data).unwrap(), {
                loading: 'Loading',
                success: 'Welcome!',
                error: 'Oh, Look at the form!'
            });
            navigate('/');
        } catch (error) {
        }
    };
    return (     
        <UserForm 
            title="Login" 
            error={error as FetchBaseQueryError} 
            onSubmit={onSubmit} 
            additional={<Link to="/register" className="text-center">Create new account</Link>} />
    );
}

export default Login; 