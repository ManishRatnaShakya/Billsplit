namespace BillSplit.Domain.Entities
{
    public class Settlement
    {
        // Primary Key
        public Guid SettlementId { get; set; }

        // FK: The group where this settlement is tracked
        public Guid GroupId { get; set; }

        // FK: User who owes money
        public Guid FromUserId { get; set; }

        // FK: User who should receive the money
        public Guid ToUserId { get; set; }

        // Amount owed
        public decimal Amount { get; set; }

        // Status of settlement
        public string Status { get; set; } = "Pending"; 
        // Example: Pending, Completed, Cancelled

        // Optional note
        public string? Note { get; set; }

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public virtual Group Group { get; set; } = null!;
        public virtual User FromUser { get; set; } = null!;
        public virtual User ToUser { get; set; } = null!;
    }
}