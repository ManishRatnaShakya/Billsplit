using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration
{
    public class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            // Table Name
            builder.ToTable("Notifications");

            // Primary Key
            builder.HasKey(n => n.NotificationId);

            // Message
            builder.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(500);

            // Type
            builder.Property(n => n.Type)
                .IsRequired()
                .HasMaxLength(50);

            // IsRead
            builder.Property(n => n.IsRead)
                .IsRequired()
                .HasDefaultValue(false);

            // Timestamp
            builder.Property(n => n.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            // Relationships
            builder.HasOne(n => n.User)
                .WithMany() // A user can have many notifications
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(n => n.Group)
                .WithMany()
                .HasForeignKey(n => n.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(n => n.Expense)
                .WithMany()
                .HasForeignKey(n => n.ExpenseId)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(n => n.Payment)
                .WithMany()
                .HasForeignKey(n => n.PaymentId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}