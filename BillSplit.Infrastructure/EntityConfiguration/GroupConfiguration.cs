using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BillSplit.Infrastructure.EntityConfiguration;

public class GroupConfiguration
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        // Set the primary key.
        builder.HasKey(e => e.Id);

        // Configure properties with validation rules.
        builder.Property(e => e.Name)
            .IsRequired() // Name cannot be null.
            .HasMaxLength(30);
        
        builder.HasIndex(u => u.Name);
        
        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.ImageUrl)
            .HasMaxLength(1000);
    }
}