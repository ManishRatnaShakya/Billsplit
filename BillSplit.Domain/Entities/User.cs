namespace BillSplit.Domain.Entities;

public class User
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string? Username { get; set; } 
    public string? FirstName { get; set; } 
    public string? LastName { get; set; } 
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? PhoneNumber { get; set; }
    public string? PhoneCountryCode { get; set; }
    public DateTime JoinedDate { get; init; } = DateTime.UtcNow;
    public string? LastLoginDate { get; set; }
    public bool? IsActive { get; set; } = true;
}