import { useLoginMutation } from "./loginApi";
import { useNavigate } from "react-router-dom";
import UserForm from "./components/UserForm";
import { Link } from "react-router-dom";

const Login = ()=>{
    const navigate = useNavigate();
    const [login] = useLoginMutation();
    const onSubmit = async (data: any) => {
        try {
            await login(data).unwrap();
            navigate('/');
        } catch (error) {
        }
    };
    return (     
        <UserForm 
            title="Login" 
            onSubmit={onSubmit} 
            additional={<Link to="/register" className="text-center">Create new account</Link>} />
    );
}

export default Login; 