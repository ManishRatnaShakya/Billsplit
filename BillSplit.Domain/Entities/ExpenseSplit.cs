namespace BillSplit.Domain.Entities
{
    public class ExpenseSplit
    {
        // Composite key: ExpenseId + UserId

        public Guid ExpenseId { get; set; }   // FK -> Expense
        public Guid UserId { get; set; }      // FK -> User

        // Amount this user owes
        public decimal Amount { get; set; }

        // Status of this split
        public bool IsSettled { get; set; } = false;

        // Timestamps
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Navigation
        public virtual Expense Expense { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}