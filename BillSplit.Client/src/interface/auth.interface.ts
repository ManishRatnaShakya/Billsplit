export interface ISignUp {
    email: string;
    fullname: string;
    password: string;
    confirmPassword: string;
    PhoneNumber: string;
}

export interface ISignIn {
    email: string;
    password: string;
}

export interface LoginResponse {
    token: string
}