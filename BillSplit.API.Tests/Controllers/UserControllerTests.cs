using BillSplit.API.Controllers;
using BillSplit.Application.DTOs;
using BillSplit.Application.Interfaces;
using BillSplit.Application.Interfaces.Authentication;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using System.Threading.Tasks;

namespace BillSplit.API.Tests.Controllers;

public class UserControllerTests
{
    private readonly Mock<IUserService> _mockUserService;
    private readonly UserController _controller;

    public UserControllerTests()
    {
        _mockUserService = new Mock<IUserService>();
        // Note: The controller must be updated to use IAuthService for login logic.
        // Assuming the controller is refactored to:
        // public UserController(IUserService userService, IAuthService authService)
        // ...
        _controller = new UserController(_mockUserService.Object);
    }
    
    //-------------------------------------------------------------------------
    // SignUp Endpoint Tests
    //-------------------------------------------------------------------------

    /// <summary>
    /// Test case for a successful user sign-up.
    /// Verifies that with valid input, the controller calls the service and returns a 201 Created status.
    /// </summary>
    [Fact]
    public async Task SignUp_ValidSignUpDto_ReturnsCreatedResult()
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
        
        _mockUserService.Setup(s => s.SignUpAsync(It.IsAny<SignUpDto>()))
                        .Returns(Task.CompletedTask);

        // Act
        var result = await _controller.SignUp(signUpDto);

        // Assert
        var createdResult = Assert.IsType<CreatedResult>(result);
        Assert.NotNull(createdResult.Value);
        Assert.Equal(201, createdResult.StatusCode);
    }
}