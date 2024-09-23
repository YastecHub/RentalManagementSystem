using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentalManagementSystem.Application.Abstractions.Services;
using RentalManagementSystem.Application.DTOs;

namespace RentalManagementSystem.Hosts.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _userService.CreateUserAsync(createUserDto);
            if (result.IsSuccessful)
            {
                return Ok(result); 
            }
            return BadRequest(result);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteUser(Guid userId)
        {
            var result = await _userService.DeleteAsync(userId);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("exists/{userId}")]
        public async Task<IActionResult> UserExists(Guid userId)
        {
            var result = await _userService.ExistsAsync(userId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(Guid userId)
        {
            var result = await _userService.GetByIdAsync(userId);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return NotFound(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            var result = await _userService.GetByEmailAsync(email);
            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto,Guid userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            var result = await _userService.UpdateUser(updateUserDto, userId);

            if (result.IsSuccessful)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
