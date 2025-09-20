using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration
{
    public class ExpenseSplitConfiguration : IEntityTypeConfiguration<ExpenseSplit>
    {
        public void Configure(EntityTypeBuilder<ExpenseSplit> builder)
        {
            // Table name
            builder.ToTable("ExpenseSplits");

            // Composite primary key: ExpenseId + UserId
            builder.HasKey(es => new { es.ExpenseId, es.UserId });

            // Amount
            builder.Property(es => es.Amount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            // Status
            builder.Property(es => es.IsSettled)
                .IsRequired()
                .HasDefaultValue(false);

            // Timestamps
            builder.Property(es => es.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder.Property(es => es.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            // Relationships
            builder.HasOne(es => es.Expense)
                .WithMany() // An expense can have many splits
                .HasForeignKey(es => es.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(es => es.User)
                .WithMany() // A user can be part of many splits
                .HasForeignKey(es => es.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}