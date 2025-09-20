using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            // Table name
            builder.ToTable("Payments");

            // Primary Key
            builder.HasKey(p => p.PaymentId);

            // Amount
            builder.Property(p => p.Amount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            // Method
            builder.Property(p => p.Method)
                .IsRequired()
                .HasMaxLength(50);

            // Status
            builder.Property(p => p.Status)
                .IsRequired()
                .HasMaxLength(50);

            // Timestamps
            builder.Property(p => p.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder.Property(p => p.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            // Relationships
            builder.HasOne(p => p.FromUser)
                .WithMany() // A user can make many payments
                .HasForeignKey(p => p.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.ToUser)
                .WithMany() // A user can receive many payments
                .HasForeignKey(p => p.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.Group)
                .WithMany() // A group can have many payments
                .HasForeignKey(p => p.GroupId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}