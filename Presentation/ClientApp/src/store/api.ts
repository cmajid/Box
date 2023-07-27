import { BaseQueryFn, FetchArgs, FetchBaseQueryError, createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { AppStorage } from '../assets/utilities/storage';

export const BASE_URL = 'https://localhost:5000';

const baseQuery = fetchBaseQuery({
    baseUrl: BASE_URL,
    prepareHeaders: (header)=>{
        const token = AppStorage.Provider.getItem('token');
        if(token)
            header.set('authorization', `Bearer ${token}`);

        return header;
    }
});

const appFetchBaseQuery: BaseQueryFn<string | FetchArgs, unknown, FetchBaseQueryError> = async(
    args,
    api,
    extraOptions
) =>{
    const result = await baseQuery(args, api, extraOptions);
    if(!result.error)
        return result;
   
    if(result.error.status === 500)
        console.log("SERVER_ERROR", result.error);

    if(result.error.status === 401)
        window.location.replace("/login");
    
    return result;
}

const api = createApi({
    reducerPath: 'api',
    baseQuery: appFetchBaseQuery,
    endpoints: ()=>({}),
    tagTypes: ['DataFiles']
});

export default api;