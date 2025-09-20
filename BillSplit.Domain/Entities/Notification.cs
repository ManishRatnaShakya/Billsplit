namespace BillSplit.Domain.Entities
{
    public class Notification
    {
        // Primary Key
        public Guid NotificationId { get; set; }

        // FK: User who receives the notification
        public Guid UserId { get; set; }

        // Optional FK for context
        public Guid? GroupId { get; set; }
        public Guid? ExpenseId { get; set; }
        public Guid? PaymentId { get; set; }

        // Notification content
        public string Message { get; set; } = string.Empty;

        // Type of notification
        public string Type { get; set; } = "Info"; 
        // Example values: "Info", "ExpenseAdded", "PaymentMade", "GroupUpdate"

        // Status
        public bool IsRead { get; set; } = false;

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public virtual User User { get; set; } = null!;
        public virtual Group? Group { get; set; }
        public virtual Expense? Expense { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}