import baseApiService from "./BaseApi.service.ts";
import type {ISignIn, ISignUp} from "../interface/auth.interface.ts";
import type {ApiResponse} from "../common/ApiResponse.type.ts";
import type {LoginResponse} from "../types/auth.type.ts";


// User related API calls
const AuthService = {
    login: (data: ISignIn): Promise<ApiResponse<LoginResponse>> =>
        baseApiService.post("/user/login", data),

    register: (data: ISignUp) : Promise<ApiResponse>  =>
        baseApiService.post("/user/register", data),

    getProfile: () => baseApiService.get("/users/profile"),
};

export default AuthService;