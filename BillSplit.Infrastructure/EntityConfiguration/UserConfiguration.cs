using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    // The Configure method is where you place all the validation and
    // relationship mapping for a single entity.
    public void Configure(EntityTypeBuilder<User> builder)
    {
        // Set the primary key.
        builder.HasKey(e => e.Id);

        // Configure properties with validation rules.
        builder.Property(e => e.FirstName)
            .IsRequired() // Name cannot be null.
            .HasMaxLength(100);
        
        builder.Property(e => e.FirstName)
            .IsRequired() // Name cannot be null.
            .HasMaxLength(100);

        builder.Property(e => e.Email)
            .IsRequired() // Email cannot be null.
            .HasMaxLength(256); // A common standard for email length.

        // The Email must be unique to prevent duplicate user accounts.
        builder.HasIndex(e => e.Email)
            .IsUnique();

        // PasswordHash is required. Its length will depend on the hashing algorithm used.
        builder.Property(e => e.Password)
            .IsRequired();

        // The JoinedDate property is required and the value is generated in the application.
        builder.Property(e => e.JoinedDate)
            .IsRequired();

        // LastLoginDate property is required.
        builder.Property(e => e.LastLoginDate)
            .IsRequired();
            
        // IsActive is a required boolean field.
        builder.Property(e => e.IsActive)
            .IsRequired();

        // These properties are optional but have a maximum length.
        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(15);
        builder.Property(e => e.PhoneCountryCode)
            .HasMaxLength(4);
    }
}