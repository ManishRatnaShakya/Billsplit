import { useForm } from "react-hook-form";
import * as yup from "yup";
import { yupResolver } from "@hookform/resolvers/yup";
import axios from "axios";
import { Router } from "react-router-dom";
import { useNavigate } from "react-router-dom";

// ✅ Schema
const userSchema = yup.object().shape({
    username: yup.string().required("Username is required"),
    password: yup.string().required("Password is required"),
});

type FormData = yup.InferType<typeof userSchema>;

export function LoginForm() {
    const navigate = useNavigate();
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<FormData>({
        resolver: yupResolver(userSchema),
    });

    // ✅ Submit handler
    const  onSubmit = async (data: FormData) => {
        try {
            const response = await axios.post("http://localhost:5003/api/User/Login", data);

            const token = response.data.data.token; // adjust this key to match your backend
            console.log(token);
            localStorage.setItem("token", token);
            console.log("Login success:", response.data);

            navigate("/dashboard");
        } catch (error: any) {
            if (axios.isAxiosError(error)) {
                console.error("Login failed:", error.response?.data || error.message);
            } else {
                console.error("Unexpected error:", error);
            }
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
                                        className="border rounded px-3 py-2 w-full"
                                        {...register("username")}
                                    />
                                    {errors.username && (
                                        <p className="text-red-500 text-xs mt-1">
                                            {errors.username.message}
                                        </p>
                                    )}

                                    {/* ✅ Password */}
                                    <input
                                        type="password"
                                        placeholder="Password"
                                        className=" border rounded px-3 py-2 w-full mt-5"
                                        {...register("password")}
                                    />
                                    {errors.password && (
                                        <p className="text-red-500 text-xs mt-1">
                                            {errors.password.message}
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
