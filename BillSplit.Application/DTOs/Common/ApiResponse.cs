namespace BillSplit.Application.DTOs.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }

        public ApiResponse() { }

        public ApiResponse(bool success, string message, T? data = default)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        // Helpers
        public static ApiResponse<T> SuccessResponse(T data, string message = "Request successful")
        {
            return new ApiResponse<T>(true, message, data);
        }

        public static ApiResponse<T> FailureResponse(string message)
        {
            return new ApiResponse<T>(false, message);
        }
    }
}