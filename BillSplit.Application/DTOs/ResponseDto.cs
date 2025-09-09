namespace BillSplit.Application.DTOs;

public class ResponseDto<T>(string message, T data)
{
    public string Message { get; set; } = message;
    public T Data { get; set; } = data;
}