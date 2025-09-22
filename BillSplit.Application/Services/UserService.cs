using BillSplit.Application.DTOs;
using BillSplit.Application.DTOs.Common;
using BillSplit.Application.Interfaces;
using BillSplit.Application.Interfaces.Authentication;
using BillSplit.Application.Interfaces.Common;
using BillSplit.Domain.Interfaces.Repos;
using BillSplit.Domain.Entities;

namespace BillSplit.Application.Services;

/// <summary>
/// Service class for user-related operations, handling business logic.
/// </summary>
public class UserService(IUserRepository userRepository,
                            IUnitOfWork unitOfWork,
                            IPasswordHasher passwordHasher,
                            IJwtService jwtService)
    : IUserService
{
    
    
    public async Task<ApiResponse<LoginResponseDto>> LoginAsync(LoginDto loginDto)
    {
        var user = await userRepository.GetByEmailAsync(loginDto.Email);

        if (user == null)
            return ApiResponse<LoginResponseDto>.FailureResponse("User not found");

        // ✅ Correct parameter order
        if (!passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash))
            return ApiResponse<LoginResponseDto>.FailureResponse("Invalid password");

        var token = jwtService.GenerateJwtToken(user);

        var responseDto = new LoginResponseDto
        {
            Token = token,
            Email = user.Email,
            Fullname = user.FullName
        };

        return ApiResponse<LoginResponseDto>.SuccessResponse(responseDto, "Login successful");
    }

    public async Task<ApiResponse<SignUpDto>> SignUpAsync(SignUpDto userDto)
    {
        // 1. Check if user already exists
        if (await userRepository.UserExistsAsync(userDto.Email))
        {
            return ApiResponse<SignUpDto>.FailureResponse("User with this email already exists.");
        }

        // 2. Securely hash the password using BCrypt
        var passwordHash = passwordHasher.HashPassword(userDto.Password);

        // 3. Create new user entity
        var user = new User
        {
            UserId = Guid.NewGuid(),
            FullName = userDto.FullName,
            Email = userDto.Email,
            PasswordHash = passwordHash, // ✅ Store only the hashed password
            ProfileImage = userDto.ProfileImage,
            PhoneNumber = userDto.PhoneNumber,
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        // 4. Add to repository
        userRepository.AddUser(user);

        // 5. Commit transaction
        await unitOfWork.SaveChangesAsync();

        // 6. Prepare response DTO (don’t return the password)
        var responseDto = new SignUpDto
        {
            FullName = user.FullName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            ProfileImage = user.ProfileImage
        };

        return ApiResponse<SignUpDto>.SuccessResponse(responseDto, "User registered successfully!");
    }

    public async Task UpdateUser(Guid id, UserUpdateDto userUpdateDto)
    {
        var currentActiveUser = userRepository.GetUserById(id);
        
        var updateProps = userUpdateDto.GetType().GetProperties();

        foreach (var prop in updateProps)
        {
            var newValue = prop.GetValue(userUpdateDto); 
            if (newValue != null) // only update if user provided data
            {
                var targetProp = currentActiveUser.GetType().GetProperty(prop.Name);

                if (targetProp != null && targetProp.CanWrite) {
                        targetProp.SetValue(currentActiveUser, newValue); 
                } 
            }
        }

        userRepository.UpdateUser(currentActiveUser);

        await unitOfWork.SaveChangesAsync();
    }
}