using BillSplit.Domain.Entities;
using BillSplit.Domain.Interfaces.Repos;
using BillSplit.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BillSplit.Infrastructure.Data.Repos;

public class UserRepository(BillSplitDbContext context) : IUserRepository
{
    public Task<bool> UserExistsAsync(string username) =>
        context.Users.AnyAsync(u => u.FullName == username);

    public void AddUser(User user) =>
        context.Users.Add(user);
    
    public void UpdateUser(User user) =>
        context.Users.Update(user);
    
    public User GetUserById(Guid id) =>
        context.Users.Find(id);
    public User GetUserByUsername(string username) => 
        context.Users.FirstOrDefault(u => u.FullName == username);
}