import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import { useNavigate} from "react-router-dom";
import {useMutation} from "@tanstack/react-query";
import authService from "../../../services/auth.service.ts";
import type {ISignIn} from "../../../interface/auth.interface.ts";
import type {ApiResponse, ErrorResponse} from "../../../common/ApiResponse.type.ts";
import type {LoginResponse} from "../../../types/auth.type.ts";
import {useState} from "react";

// ✅ Schema
const userSchema = yup.object().shape({
    username: yup.string().required("Username is required"),
    password: yup.string().required("Password is required"),
});

export function LoginForm() {

    const navigate = useNavigate();
    const [error, setError] = useState<{username: string, password: string}>();
    
    const loginMutation = useMutation({
        mutationFn: authService.login,
        onSuccess: (response: ApiResponse<LoginResponse>) => {
            console.log(response);
            localStorage.setItem("token", response.data.data.token);
            navigate('/dashboard');
        },
        onError: (error: ApiResponse<ErrorResponse>) => {
            setError(error.response.data.data);
            console.log("Login failed:", error.message);
        },
    });
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<ISignIn>({
        resolver: yupResolver(userSchema),
    });

    const  onSubmit = async (data: ISignIn) => {
        try {
          await loginMutation.mutate(data);
        }
        catch (error) {
            console.log(error);
        }
    };

    return (
        <div className="min-h-screen bg-gray-100 text-gray-900 flex justify-center">
            <div className="max-w-screen-xl m-0 sm:m-10 bg-white shadow sm:rounded-lg flex justify-center flex-1">
                <div className="lg:w-1/2 xl:w-5/12 p-6 sm:p-12">
                    <div>
                        <img
                            src="https://storage.googleapis.com/devitary-image-host.appspot.com/15846435184459982716-LogoMakr_7POjrN.png"
                            className="w-32 mx-auto"
                        />
                    </div>

                    <div className="mt-12 flex flex-col items-center">
                        <h1 className="text-2xl xl:text-3xl font-extrabold">Sign in</h1>

                        <div className="w-full flex-1 mt-8">
                            <form onSubmit={handleSubmit(onSubmit)}>
                                <div className="mx-auto max-w-xs">
                                    {/* ✅ Email */}
                                    <input
                                        type="text"
                                        placeholder="Username"
                                        onKeyUp={() => setError(undefined)}
                                        className="w-full px-8 py-4 rounded-lg font-medium bg-gray-100 border border-gray-200 placeholder-gray-500 text-sm focus:outline-none focus:border-gray-400 focus:bg-white"
                                        {...register("username")}
                                    />
                                    {errors.username && (
                                        <p className="text-red-500 text-xs mt-1">
                                            {errors.username.message}
                                        </p>
                                    )}
                                    {error && (
                                        <p className="text-red-500 text-xs mt-1">
                                            {error.username}
                                        </p>
                                    )}

                                    {/* ✅ Password */}
                                    <input
                                        type="password"
                                        placeholder="Password"
                                        onFocus={() => setError(undefined)}
                                        className="w-full px-8 py-4 rounded-lg font-medium bg-gray-100 border border-gray-200 placeholder-gray-500 text-sm focus:outline-none focus:border-gray-400 focus:bg-white mt-5"
                                        {...register("password")}
                                    />
                                    {errors.password && (
                                        <p className="text-red-500 text-xs mt-1">
                                            {errors.password.message}
                                        </p>
                                    )}
                                    {error && (
                                        <p className="text-red-500 text-xs mt-1">
                                            {error.password}
                                        </p>
                                    )}

                                    {/* ✅ Submit */}
                                    <button
                                        type="submit"
                                        className="mt-5 tracking-wide font-semibold bg-indigo-500 text-gray-100 w-full py-4 rounded-lg hover:bg-indigo-700 transition-all duration-300 ease-in-out flex items-center justify-center focus:shadow-outline focus:outline-none"
                                    >
                                        <svg
                                            className="w-6 h-6 -ml-2"
                                            fill="none"
                                            stroke="currentColor"
                                            strokeWidth="2"
                                            strokeLinecap="round"
                                            strokeLinejoin="round"
                                        >
                                            <path d="M16 21v-2a4 4 0 00-4-4H5a4 4 0 00-4 4v2" />
                                            <circle cx="8.5" cy="7" r="4" />
                                            <path d="M20 8v6M23 11h-6" />
                                        </svg>
                                        <span className="ml-3">Sign In</span>
                                    </button>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>

                <div className="flex-1 bg-indigo-100 text-center hidden lg:flex">
                    <div
                        className="m-12 xl:m-16 w-full bg-contain bg-center bg-no-repeat"
                        style={{
                            background:
                                "url('https://storage.googleapis.com/devitary-image-host.appspot.com/15848031292911696601-undraw_designer_life_w96d.svg')",
                        }}
                    ></div>
                </div>
            </div>
        </div>
    );
}
