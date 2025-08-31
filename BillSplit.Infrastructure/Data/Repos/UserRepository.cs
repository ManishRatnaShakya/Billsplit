using BillSplit.Domain.Entities;
using BillSplit.Domain.Interfaces.Repos;
using Microsoft.EntityFrameworkCore;

namespace BillSplit.Infrastructure.Data.Repos;

public class UserRepository(BillSplitDbContext context) : IUserRepository
{
    public Task<bool> UserExistsAsync(string username) =>
        context.Users.AnyAsync(u => u.Username == username);

    public void AddUser(User user) =>
        context.Users.Add(user);
}