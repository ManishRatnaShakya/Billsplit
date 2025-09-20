namespace BillSplit.Domain.Entities
{
    public class Payment
    {
        // Primary Key
        public Guid PaymentId { get; set; }

        // FK: User who sent the payment
        public Guid FromUserId { get; set; }

        // FK: User who received the payment
        public Guid ToUserId { get; set; }

        // FK: Group (context for the payment)
        public Guid GroupId { get; set; }

        // Amount paid
        public decimal Amount { get; set; }

        // Payment details
        public string Method { get; set; } = "Cash";   // e.g., Cash, Bank Transfer, PayPal, Venmo
        public string Status { get; set; } = "Pending"; // Pending, Completed, Failed

        // Date when the payment was made
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public virtual User FromUser { get; set; } = null!; // The payer
        public virtual User ToUser { get; set; } = null!;   // The receiver
        public virtual Group Group { get; set; } = null!;
    }
}