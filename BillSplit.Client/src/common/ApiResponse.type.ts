export interface ApiResponse<T = any> {
    data: T;
    message: string
}

export interface ErrorResponse {
    message: string,
    statusCode: number,
    status: number
}