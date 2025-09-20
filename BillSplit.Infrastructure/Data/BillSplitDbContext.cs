using BillSplit.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BillSplit.Infrastructure.Persistence
{
    public class BillSplitDbContext : DbContext
    {
        public BillSplitDbContext(DbContextOptions<BillSplitDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; } 
        public DbSet<UserGroup> UserGroups { get; set; }  
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseSplit> ExpenseSplits { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Settlement> Settlements { get; set; } 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BillSplitDbContext).Assembly);
        }
    }
}