using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration
{
    public class UserGroupConfiguration : IEntityTypeConfiguration<UserGroup>
    {
        public void Configure(EntityTypeBuilder<UserGroup> builder)
        {
            // Table name
            builder.ToTable("UserGroups");

            // Composite Primary Key
            builder.HasKey(ug => new { ug.UserId, ug.GroupId });

            // Relationships
            builder.HasOne(ug => ug.User)
                .WithMany() // A user can belong to many groups
                .HasForeignKey(ug => ug.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ug => ug.Group)
                .WithMany() // A group can have many users
                .HasForeignKey(ug => ug.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // Properties
            builder.Property(ug => ug.Role)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(ug => ug.JoinedAt)
                .IsRequired()
                .HasDefaultValueSql("NOW()"); // PostgreSQL default
        }
    }
}