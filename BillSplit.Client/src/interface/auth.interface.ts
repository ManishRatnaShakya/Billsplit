export interface ISignUp {
    email: string;
    username: string;
    firstName: string;
    lastName: string;
    password: string;
    confirmPassword: string;
    PhoneNumber: string;
    PhoneCountryCode: string;
}

export interface ISignIn {
    username: string;
    password: string;
}

export interface LoginResponse {
    token: string
}