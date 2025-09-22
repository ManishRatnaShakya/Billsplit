namespace BillSplit.Application.DTOs;

public class SignUpDto
{
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    
    public string? ProfileImage { get; set; }
}

