using BillSplit.Application.DTOs;

namespace BillSplit.Application.Interfaces;

public interface IUserService
{
    Task<ResponseDTO> LoginAsync(LoginDto loginDto);
    Task SignUpAsync(SignUpDto userDto);
    Task UpdateUser(Guid id, UserUpdateDto userUpdateDto);
}