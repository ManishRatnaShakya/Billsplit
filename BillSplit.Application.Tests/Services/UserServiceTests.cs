using BillSplit.Application.DTOs;
using BillSplit.Application.Interfaces.Authentication;
using BillSplit.Application.Interfaces.Common;
using BillSplit.Application.Services;
using BillSplit.Domain.Entities;
using BillSplit.Domain.Interfaces.Repos;
using Moq;

namespace BillSplit.Application.Tests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IPasswordHasher> _mockPasswordHasher;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockPasswordHasher = new Mock<IPasswordHasher>();
        _userService = new UserService(
            _mockUserRepository.Object,
            _mockUnitOfWork.Object,
            _mockPasswordHasher.Object
        );
    }

    //-------------------------------------------------------------------------
    // SignUpAsync Method Tests
    //-------------------------------------------------------------------------

    /// <summary>
    /// Test case for a successful user sign-up.
    /// Verifies that the service performs all the correct steps:
    /// 1. Checks if the user exists.
    /// 2. Hash the password.
    /// 3. Add the new user to the repository.
    /// 4. Save changes to the database.
    /// </summary>
    [Fact]
    public async Task SignUpAsync_ValidUser_AddsUserAndSavesChanges()
    {
        // Arrange
        var signUpDto = new SignUpDto
        {
            Username = "test",
            FirstName = "Test",
            LastName = "Test",
            Email = "test@gmail.com",
            Password = "HelloWorld"
        };
        var hashedPassword = "hashed_password_mock";

        // Setup mocks to simulate a new user and successful operations
        _mockUserRepository.Setup(r => r.UserExistsAsync(signUpDto.Username))
            .ReturnsAsync(false);
        _mockPasswordHasher.Setup(h => h.HashPassword(signUpDto.Password))
            .Returns(hashedPassword);
        _mockUnitOfWork.Setup(u => u.SaveChangesAsync(default))
            .ReturnsAsync(1);
        
        // Act
        await _userService.SignUpAsync(signUpDto);

        // Assert
        // Verify that UserExistsAsync was called exactly once.
        _mockUserRepository.Verify(r => r.UserExistsAsync(signUpDto.Username), Times.Once);

        // Verify that the password was hashed.
        _mockPasswordHasher.Verify(h => h.HashPassword(signUpDto.Password), Times.Once);

        // Verify that the AddUser method was called exactly once with a new User entity.
        _mockUserRepository.Verify(r => r.AddUser(It.Is<User>(u => 
            u.Username == signUpDto.Username && u.Password == hashedPassword
        )), Times.Once);

        // Verify that SaveChangesAsync was called exactly once to persist the changes.
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(default), Times.Once);
    }

    /// <summary>
    /// Test case for a sign-up attempt with a username that already exists.
    /// Verifies that the service throws an exception and does not proceed with adding the user
    /// or saving changes.
    /// </summary>
    [Fact]
    public async Task SignUpAsync_ExistingUser_ThrowsExceptionAndDoesNotSave()
    {
        // Arrange
        var signUpDto = new SignUpDto
        {
            Username = "test",
            FirstName = "Test",
            LastName = "Test",
            Email = "test@gmail.com",
            Password = "HelloWorld"
        };

        // Set up the user repository mock to return true for user existence
        _mockUserRepository.Setup(r => r.UserExistsAsync(signUpDto.Username))
            .ReturnsAsync(true);

        // Act & Assert
        // Verify that an exception is thrown with the expected message.
        var exception = await Assert.ThrowsAsync<Exception>(() => _userService.SignUpAsync(signUpDto));
        Assert.Equal("Username already exists.", exception.Message);

        // Assert that no further methods were called after the user existence check failed.
        _mockUserRepository.Verify(r => r.UserExistsAsync(signUpDto.Username), Times.Once);
        _mockPasswordHasher.Verify(h => h.HashPassword(It.IsAny<string>()), Times.Never);
        _mockUserRepository.Verify(r => r.AddUser(It.IsAny<User>()), Times.Never);
        _mockUnitOfWork.Verify(u => u.SaveChangesAsync(default), Times.Never);
    }
}