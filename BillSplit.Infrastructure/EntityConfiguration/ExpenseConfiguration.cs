using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration;

public class ExpenseConfiguration
{
    
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        // Table name
        builder.ToTable("Expenses");

        // Primary Key
        builder.HasKey(e => e.ExpenseId);

        // Title
        builder.Property(e => e.Title)
            .IsRequired()
            .HasMaxLength(150);

        // Description
        builder.Property(e => e.Description)
            .HasMaxLength(500);

        // Total Amount
        builder.Property(e => e.TotalAmount)
            .IsRequired()
            .HasColumnType("decimal(10,2)");

        // Date incurred
        builder.Property(e => e.DateIncurred)
            .IsRequired();

        // Timestamps
        builder.Property(e => e.CreatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()"); // PostgreSQL default

        builder.Property(e => e.UpdatedAt)
            .IsRequired()
            .HasDefaultValueSql("NOW()");

        // Relationship: Expense -> Group
        builder.HasOne(e => e.Group)
            .WithMany() // A group can have many expenses
            .HasForeignKey(e => e.GroupId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship: Expense -> Creator (User)
        builder.HasOne(e => e.Creator)
            .WithMany() // A user can create many expenses
            .HasForeignKey(e => e.CreatedBy)
            .OnDelete(DeleteBehavior.Restrict);
}
}