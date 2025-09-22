using BillSplit.Application.DTOs;
using BillSplit.Application.DTOs.Common;
using BillSplit.Domain.Entities;

namespace BillSplit.Application.Interfaces;

public interface IUserService
{
    Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto);
    Task<ApiResponse<SignUpDto>> SignUpAsync(SignUpDto request);
    Task UpdateUser(Guid id, UserUpdateDto userUpdateDto);
   
}