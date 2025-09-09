import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import axios from "axios";

type FormData = {
    email: string;
    username: string;
    firstName: string;
    lastName: string;
    password: string;
    confirmPassword: string;
    PhoneNumber: string;
    PhoneCountryCode: string;
};

// ✅ Define Yup schema
const schema = yup.object().shape({
    email: yup.string().email("Invalid email").required("Email is required"),
    username: yup.string().required("Username is required"),
    firstName: yup.string().required("First name is required"),
    lastName: yup.string().required("Last name is required"),
    password: yup.string().min(6, "Password must be at least 6 chars").required(),
    confirmPassword: yup
        .string()
        .oneOf([yup.ref("password"), ""], "Passwords must match")
        .required("Confirm password is required"),
    PhoneNumber: yup.string().required("Phone number is required"),
    PhoneCountryCode: yup.string().required("Country code is required"),
});

export default function RegistrationCard() {
    // ✅ Hook Form setup
    const {
        register,
        handleSubmit,
        formState: { errors },
    } = useForm<FormData>({
        resolver: yupResolver(schema),
    });

    // ✅ Handle form submit
    const onSubmit = (data: FormData) => {
       try {
           const req = axios.post("http://localhost:5003/api/User/signUp", data)
           console.log(req)
       }catch (error) {
           console.log(error)
       }
           
    };

    return (
        <div className="min-h-screen bg-gray-100 text-gray-900 flex justify-center">
            <div className="max-w-screen-xl m-0 sm:m-10 bg-white shadow sm:rounded-lg flex justify-center flex-1">
                <div className="lg:w-1/2 xl:w-5/12 p-6 sm:p-12">
                    <div>
                        <p className="w-32 xl:text-3xl font-extrabold italic mx-auto">
                            BillSplit
                        </p>
                    </div>

                    <div className="mt-12 flex flex-col items-center">
                        <h1 className="text-2xl xl:text-3xl font-extrabold">Sign up</h1>

                        <form
                            className="w-full flex-1 mt-8"
                            onSubmit={handleSubmit(onSubmit)}
                        >
                            <div className="mx-auto max-w-xs">
                                <input
                                    type="text"
                                    placeholder="Email"
                                    className="border rounded px-3 py-2 w-full"
                                    {...register("email")}
                                />
                                {errors.email && (
                                    <p className="text-red-500 text-xs">{errors.email.message}</p>
                                )}

                                <input
                                    type="text"
                                    placeholder="Username"
                                    className="border rounded px-3 py-2 w-full"
                                    {...register("username")}
                                />
                                {errors.username && (
                                    <p className="text-red-500 text-xs">{errors.username.message}</p>
                                )}

                                <input
                                    type="text"
                                    placeholder="first name"
                                    className="border rounded px-3 py-2 w-full"
                                    {...register("firstName")}
                                />
                                {errors.firstName && (
                                    <p className="text-red-500 text-xs">{errors.firstName.message}</p>
                                )}
                                <input
                                    type="text"
                                    placeholder="LastName"
                                    className="border rounded px-3 py-2 w-full"
                                    {...register("lastName")}
                                />
                                {errors.lastName && (
                                    <p className="text-red-500 text-xs">{errors.lastName.message}</p>
                                )}
                                <input
                                    type="password"
                                    placeholder="Password"
                                    className=" border rounded px-3 py-2 w-full mt-5"
                                    
                                    
                                    {...register("password")}
                                />
                                {errors.password && (
                                    <p className="text-red-500 text-xs">
                                        {errors.password.message}
                                    </p>
                                )}

                                <input
                                    type="password"
                                    placeholder="Confirm Password"
                                    className="border rounded px-3 py-2 w-full mt-5"
                                    {...register("confirmPassword")}
                                />
                                {errors.confirmPassword && (
                                    <p className="text-red-500 text-xs">
                                        {errors.confirmPassword.message}
                                    </p>
                                )}

                                <input
                                    type="text"
                                    placeholder="Phone Number"
                                    className="border rounded px-3 py-2 w-full mt-5"
                                    {...register("PhoneNumber")}
                                />
                                {errors.PhoneNumber && (
                                    <p className="text-red-500 text-xs">
                                        {errors.PhoneNumber.message}
                                    </p>
                                )}

                                <input
                                    type="text"
                                    placeholder="Country Code"
                                    className="border rounded px-3 py-2 w-full mt-5"
                                    {...register("PhoneCountryCode")}
                                />
                                {errors.PhoneCountryCode && (
                                    <p className="text-red-500 text-xs">
                                        {errors.PhoneCountryCode.message}
                                    </p>
                                )}

                                <button
                                    type="submit"
                                    className="mt-5 tracking-wide font-semibold bg-indigo-500 text-gray-100 w-full py-4 rounded-lg hover:bg-indigo-700 transition-all duration-300 flex items-center justify-center focus:shadow-outline focus:outline-none"
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
                                    <span className="ml-3">Sign Up</span>
                                </button>
                            </div>
                        </form>
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
