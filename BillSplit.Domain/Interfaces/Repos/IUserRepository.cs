using BillSplit.Domain.Entities;

namespace BillSplit.Domain.Interfaces.Repos;

public interface IUserRepository
{
    Task<bool> UserExistsAsync(string username);
    void AddUser(User user);
    
    User GetUserById(Guid id);
    
    Task<User> GetByEmailAsync(string username);
    void UpdateUser(User user);
}