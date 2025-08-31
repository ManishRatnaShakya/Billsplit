namespace BillSplit.Application.DTOs;

public class SignUpDto
{
    public required string Username { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneCountryCode { get; set; }
}