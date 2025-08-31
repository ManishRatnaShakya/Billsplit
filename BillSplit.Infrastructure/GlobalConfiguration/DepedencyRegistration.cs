using BillSplit.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BillSplit.Infrastructure.GlobalConfiguration;

public static class DepedencyRegistration
{
    public static void ServiceRegistration(this IServiceCollection services, string connectionString)
    {
        // Register repositories from the Infrastructure layer

        // Register services from the Application layer

        // Register any other infrastructure services (like logging, caching, etc.)
        services.AddDbContext<BillSplitDbContext>(options =>
            options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(typeof(BillSplitDbContext).Assembly.FullName)));
    }
}