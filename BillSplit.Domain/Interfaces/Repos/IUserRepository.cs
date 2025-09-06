using BillSplit.Domain.Entities;

namespace BillSplit.Domain.Interfaces.Repos;

public interface IUserRepository
{
    Task<bool> UserExistsAsync(string username);
    void AddUser(User user);
    
    User GetUserById(Guid id);
    
    User GetUserByUsername(string username);
    void UpdateUser(User user);
}