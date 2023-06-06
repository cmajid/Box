import { FetchBaseQueryError } from "@reduxjs/toolkit/dist/query";

type props = {
    error: FetchBaseQueryError;
}

type ErrorResponse = {
    Messages: string[];
    IsSucceed: boolean;
}

const ErrorHandler = ({error} : props)=>{
    const {data} = error;
    const messages = (data as ErrorResponse).Messages;
    return (
        <div className={`mt-2 text-red-500`}>
            {messages.map((message, index)=> <p key={index}>{message}</p>)}
        </div>
    );
}

export default ErrorHandler;