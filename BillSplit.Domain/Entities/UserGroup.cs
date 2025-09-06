namespace BillSplit.Domain.Entities;

public class UserGroup
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;

    public Guid GroupId { get; set; }
    public Group Group { get; set; } = null!;

    // Extra columns if needed
    public DateTime JoinedAt { get; set; } = DateTime.UtcNow;
}
