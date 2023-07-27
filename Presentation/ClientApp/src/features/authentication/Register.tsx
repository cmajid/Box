import { Link, useNavigate } from "react-router-dom";
import UserForm from "./components/UserForm";
import { useRegisterMutation } from "./loginApi";
import toast from "react-hot-toast";

const Register = ()=>{
    const navigate = useNavigate();
    const [register] = useRegisterMutation();
    const onSubmit = async (data: any) => {
        try {
            await register(data).unwrap();
            toast('Login with your Username and Password', {
                icon: '👏',
                duration: 5000,
            });
            navigate('/login');
        } catch (error) {}
    };
    return (
        <UserForm 
            title="Register" 
            onSubmit={onSubmit} 
            additional={<Link to="/login" className="text-center">Already have an acount?</Link>}/>);
}

export default Register;