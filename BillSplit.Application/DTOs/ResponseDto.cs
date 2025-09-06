namespace BillSplit.Application.DTOs;

public class ResponseDTO<T>
{
    public string message { get; set; }
    public T data { get; set; }

    public ResponseDTO(string message, T data)
    {
        message = message;
        data = data;
    }
}