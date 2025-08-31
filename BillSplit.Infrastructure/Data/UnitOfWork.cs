using BillSplit.Application.Interfaces.Common;

namespace BillSplit.Infrastructure.Data;

/// <summary>
/// Implements the Unit of Work pattern to manage database transactions.
/// </summary>
public class UnitOfWork :  IUnitOfWork
{
    private readonly BillSplitDbContext _context;

    /// <summary>
    /// Initializes a new instance of the UnitOfWork with the database context.
    /// </summary>
    /// <param name="context">The application's database context.</param>
    public UnitOfWork(BillSplitDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Commits all pending changes in the tracked entities to the database.
    /// </summary>
    /// <param name="cancellationToken">A token to observe while waiting for the task to complete.</param>
    /// <returns>The number of state entries written to the database.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}