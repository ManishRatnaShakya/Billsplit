using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillSplit.Infrastructure.Data;

/// <summary>
/// Represents the database context for the BillSplit application.
/// This class is the primary entry point for querying and saving entity data to the underlying database.
/// It inherits from <see cref="DbContext"/> and is configured to use the specified <see cref="DbContextOptions"/>.
/// </summary>
public class BillSplitDbContext(DbContextOptions<BillSplitDbContext> options) : DbContext(options)
{
    /// <summary>
    /// A <see cref="DbSet{TEntity}"/> for the <see cref="User"/> entity.
    /// This property represents a collection of all entities in the context, or that can be queried from the database,
    /// and it is typically used for querying and performing CRUD (Create, Read, Update, Delete) operations.
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types
    /// exposed in <see cref="DbSet{TEntity}"/> properties on this context.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // This line tells Entity Framework to find and apply all configurations
        // that implement IEntityTypeConfiguration from the current assembly.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BillSplitDbContext).Assembly);
    }
}