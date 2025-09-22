using BillSplit.Application.DTOs;
using BillSplit.Application.DTOs.Common;
using BillSplit.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BillSplit.API.Controllers
{
    /// <summary>
    /// API controller for managing user-related operations, such as sign-up and login.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        /// <summary>
        /// Handles user login. Note: This is a placeholder and should be implemented with proper authentication logic.
        /// </summary>
        /// <param name="loginDto">The data transfer object containing login credentials.</param>
        /// <returns>An action result indicating the outcome of the login attempt.</returns>
      
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await userService.LoginAsync(loginDto);

            if (!response.Success)
            {
                // return 401 Unauthorized with consistent response
                return Unauthorized(response);
            }

            // return 200 OK with token
            return Ok(response);
        }



        
        /// <summary>
        /// Registers a new user with the provided details.
        /// </summary>
        /// <param name="signUpDto">The data transfer object containing user sign-up information.</param>
        /// <returns>An action result indicating the outcome of the registration.</returns>
        [HttpPost("register")]
        public async Task<IActionResult> SignUp([FromBody] SignUpDto signUpDto)
        {
            var response = await userService.SignUpAsync(signUpDto);

            if (!response.Success)
            {
                // If failure, return 400 Bad Request with consistent API response
                return BadRequest(response);
            }

            // On success, return 201 Created with response
            return CreatedAtAction(nameof(SignUp), new { id = response.Data?.Email }, response);
        }

        
        
        [HttpPatch("update")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserUpdateDto userUpdateDto)
        {
            await userService.UpdateUser(id, userUpdateDto);
            return Created("", new { Message = "User updated successfully." });
        }
    }
}
