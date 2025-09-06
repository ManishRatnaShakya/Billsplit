using BillSplit.Domain.Entities;

namespace BillSplit.Application.Interfaces.Authentication;

public interface IJwtService
{
    string GenerateJwtToken(User user);
}