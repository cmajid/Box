import { Link, useNavigate } from "react-router-dom";
import UserForm from "./components/UserForm";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";
import { useRegisterMutation } from "./loginApi";
import toast from "react-hot-toast";

const Register = ()=>{
    const navigate = useNavigate();
    const [register, {error}] = useRegisterMutation();
    const onSubmit = async (data: any) => {
        try {
            await toast.promise(register(data).unwrap(), {
                loading: 'Loading',
                success: 'Good Job!',
                error: 'Oh, Look at the form!',
            });
            toast('Enter your Username and Password', {
                icon: '👏',
                duration: 5000,
            });
            navigate('/login');
        } catch (error) {}
    };
    return (
        <UserForm 
            title="Register" 
            error={error as FetchBaseQueryError} 
            onSubmit={onSubmit} 
            additional={<Link to="/login" className="text-center">Already have an acount?</Link>}/>);
}

export default Register;