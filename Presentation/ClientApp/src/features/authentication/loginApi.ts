import { AppStorage } from "../../assets/utilities/storage";
import api from "../../store/api";

export interface Login {
    username: string;
    password: string;
}

export interface LoginResponse {
    token: string;
}

const LOGIN_URL = '/login';

export const loginApi = api.injectEndpoints({
    endpoints: (builder) => ({
        login: builder.mutation<LoginResponse, Login>({
            query: (data: Login) => ({
                url: LOGIN_URL,
                method: 'POST',
                body: data
            }),
            async onQueryStarted(_arg, {queryFulfilled}){
                try {
                    const {data} = await queryFulfilled;
                    AppStorage.Provider.setItem("token", data.token);
                } catch (error) {
                }
            }
        })
    })
})

export const { useLoginMutation } = loginApi;