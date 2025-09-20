namespace BillSplit.Domain.Entities
{
    public class Group
    {
        // Primary Key
        public Guid GroupId { get; set; }

        // Group Details
        public string GroupName { get; set; } = string.Empty;

        public string? Description { get; set; }

        public string? GroupImage { get; set; } // Optional group picture or icon

        // Created By (FK -> User)
        public Guid CreatedBy { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Property
        public virtual User Creator { get; set; } = null!;
    }
}