namespace BillSplit.Domain.Entities
{
    public class UserGroup
    {
        // Composite Primary Key will be (UserId + GroupId)

        public Guid UserId { get; set; }    // FK to User
        public Guid GroupId { get; set; }   // FK to Group

        // Additional fields
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        public string Role { get; set; } = "Member"; 
        // Example roles: Admin, Member, Viewer

        // Navigation Properties
        public virtual User User { get; set; } = null!;
        public virtual Group Group { get; set; } = null!;
    }
}