using expense_tracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace expense_tracker.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController(AuthService authService) : ControllerBase
    {
        private readonly AuthService _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserDto userDto) {
            var success = await _authService.Register(userDto.Username, userDto.Password);
            if (!success)
            {
                return BadRequest("Username already exists");
            }

            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto userDto) {
            var token = await _authService.Login(userDto.Username, userDto.Password);
            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }

    public class UserDto{
        public string Username { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}