namespace BillSplit.Domain.Entities
{
    public class Expense
    {
        // Primary Key
        public Guid ExpenseId { get; set; }

        // FK: Group where this expense belongs
        public Guid GroupId { get; set; }

        // FK: User who created/added this expense
        public Guid CreatedBy { get; set; }

        // Expense Details
        public string Title { get; set; } = string.Empty;   // Example: "Dinner", "Hotel"
        public string? Description { get; set; }            // Optional details
        public decimal TotalAmount { get; set; }            // Total cost

        public DateTime DateIncurred { get; set; } = DateTime.UtcNow; // When the expense happened

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation Properties
        public virtual Group Group { get; set; } = null!;      // Group this expense belongs to
        public virtual User Creator { get; set; } = null!;     // User who added the expense
    }
}