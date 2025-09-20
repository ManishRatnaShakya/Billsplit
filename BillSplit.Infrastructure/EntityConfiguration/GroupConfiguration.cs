using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            // Table name
            builder.ToTable("Groups");

            // Primary Key
            builder.HasKey(g => g.GroupId);

            // Group Name
            builder.Property(g => g.GroupName)
                .IsRequired()
                .HasMaxLength(100);

            // Description (optional)
            builder.Property(g => g.Description)
                .HasMaxLength(500);

            // Group Image (optional)
            builder.Property(g => g.GroupImage)
                .HasMaxLength(255);

            // Timestamps
            builder.Property(g => g.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            builder.Property(g => g.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()");

            // Relationship: Group -> Creator (User)
            builder.HasOne(g => g.Creator)
                .WithMany() // Creator can make multiple groups
                .HasForeignKey(g => g.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}