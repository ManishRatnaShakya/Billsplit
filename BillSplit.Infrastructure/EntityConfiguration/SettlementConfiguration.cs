using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration
{
    public class SettlementConfiguration : IEntityTypeConfiguration<Settlement>
    {
        public void Configure(EntityTypeBuilder<Settlement> builder)
        {
            // Table Name
            builder.ToTable("Settlements");

            // Primary Key
            builder.HasKey(s => s.SettlementId);

            // Amount
            builder.Property(s => s.Amount)
                .IsRequired()
                .HasColumnType("decimal(10,2)");

            // Status
            builder.Property(s => s.Status)
                .IsRequired()
                .HasMaxLength(50)
                .HasDefaultValue("Pending");

            // Optional Note
            builder.Property(s => s.Note)
                .HasMaxLength(500);

            // Timestamps
            builder.Property(s => s.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder.Property(s => s.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            // Relationships
            builder.HasOne(s => s.Group)
                .WithMany() 
                .HasForeignKey(s => s.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.FromUser)
                .WithMany()
                .HasForeignKey(s => s.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.ToUser)
                .WithMany()
                .HasForeignKey(s => s.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}