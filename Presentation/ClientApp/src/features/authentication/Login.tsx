import { useForm } from "react-hook-form";
import { useLoginMutation } from "./loginApi";
import { useNavigate } from "react-router-dom";
import ErrorHandler from "../../components/ErrorHandler";
import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

const Login = ()=>{

    const [login, {error}] = useLoginMutation();
    const navigate = useNavigate();
    const {
        register,
        handleSubmit,
        formState: { errors }
      } = useForm();

      const onSubmit = async (data: any) => {
        try {
             await login(data).unwrap();
             navigate('/');
        } catch (error) {
        }
      };

    return (
        <div className="bg-slate-100 w-screen h-screen flex items-center justify-center">
            <form onSubmit={handleSubmit(onSubmit)} className="w-1/3 bg-white shadow-md rounded p-4  flex flex-col">
                
                <h2 className="text-4xl font-bold text-center mb-5">BOX</h2>
                <div className="mb-4">
                    <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="username">
                        Username
                    </label>
                    <input  {...register("username", { required: true })}  className="shadow appearance-none border rounded w-full py-2 px-3 text-grey-darker" id="username" type="text"  />
                    {errors.username && <p>This field is required</p>}
                </div>
                <div className="mb-6">
                    <label className="block text-grey-darker text-sm font-bold mb-2" htmlFor="password">
                        Password
                    </label>
                    <input {...register("password", { required: true })} className="shadow appearance-none border border-red rounded w-full py-2 px-3 text-grey-darker" id="password" type="password"  />
                    {errors.password && <p>This field is required</p>}
                </div>
                <button className="bg-blue-600 hover:bg-blue-dark text-white font-bold py-2 px-4 rounded">
                    Sign In
                </button>
                {error && <ErrorHandler error={error as FetchBaseQueryError}/>}
            </form>
        </div>
    );
}

export default Login; 