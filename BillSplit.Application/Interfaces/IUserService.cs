using BillSplit.Application.DTOs;

namespace BillSplit.Application.Interfaces;

public interface IUserService
{
    Task LoginAsync(LoginDto loginDto);
    Task SignUpAsync(SignUpDto userDto);
}