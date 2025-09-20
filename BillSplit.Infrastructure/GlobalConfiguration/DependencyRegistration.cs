using BillSplit.Application.Interfaces;
using BillSplit.Application.Interfaces.Authentication;
using BillSplit.Application.Interfaces.Common;
using BillSplit.Application.Services;
using BillSplit.Domain.Interfaces.Repos;
using BillSplit.Infrastructure.Data;
using BillSplit.Infrastructure.Data.Repos;
using BillSplit.Infrastructure.Persistence;
using BillSplit.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BillSplit.Infrastructure.GlobalConfiguration;

public static class DependencyRegistration
{
    public static void ServiceRegistration(this IServiceCollection services, string connectionString)
    {
        // Register repositories from the Infrastructure layer
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        // Register services from the Application layer
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();
        services.AddScoped<IJwtService, JwtService>();
        // Register any other infrastructure services (like logging, caching, etc.)
        services.AddDbContext<BillSplitDbContext>(options =>
            options.UseNpgsql(connectionString,
                b => b.MigrationsAssembly(typeof(BillSplitDbContext).Assembly.FullName)));
    }
}