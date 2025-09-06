using BillSplit.Application.DTOs;
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
    
    
    public async Task<ResponseDTO> LoginAsync(LoginDto loginDto)
    {
        if (!await userRepository.UserExistsAsync(loginDto.Username))
            throw new Exception("Username does not exist.");

        var user = userRepository.GetUserByUsername(loginDto.Username);

        var passwordChecker = passwordHasher.VerifyPassword(loginDto.Password, user.Password);
        if (!passwordChecker)
            throw new Exception("Invalid password.");
        return new ResponseDTO()
        {
            data = jwtService.GenerateJwtToken(user),
            message = "Login Successful"
        };
    }

    /// <summary>
    /// Registers a new user with the provided sign-up details.
    /// </summary>
    /// <param name="userDto">The data transfer object containing user sign-up information.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    /// <exception cref="Exception">Thrown if the username already exists.</exception>
    public async Task SignUpAsync(SignUpDto userDto)
    {
        // 1. Check if a user with the given username already exists to prevent duplicates.
        if (await userRepository.UserExistsAsync(userDto.Username))
        {
            throw new Exception("Username already exists.");
        }
        
        // 2. Securely hash the plain-text password before storing it in the database.
        var passwordHash = passwordHasher.HashPassword(userDto.Password);
        
        // 3. Create a new User entity from the DTO and assign the hashed password.
        var user = new User
        {
            Username = userDto.Username,
            Email = userDto.Email,
            Password = passwordHash,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            PhoneNumber = userDto.PhoneNumber,
            PhoneCountryCode = userDto.PhoneCountryCode,
        };
        
        // Add the new user entity to the repository's change tracker.
        userRepository.AddUser(user);
        
        // 4. Persist all changes (the new user) to the database within a single transaction.
        await unitOfWork.SaveChangesAsync();
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