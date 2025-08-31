using BillSplit.Domain.Entities;

namespace BillSplit.Domain.Interfaces.Repos;

public interface IUserRepository
{
    Task<bool> UserExistsAsync(string username);
    void AddUser(User user);
}