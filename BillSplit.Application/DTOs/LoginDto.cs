namespace BillSplit.Application.DTOs;

public class LoginDto
{
    
    public required string  Email { get; set; }
    public required string Password { get; set; }
    
}

public class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;
    
    public string Email { get; set; } = string.Empty;
    public string Fullname { get; set; } = string.Empty;
}