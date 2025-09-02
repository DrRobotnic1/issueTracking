using API.Dtos.Auth;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
  [Route("api/v1/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly AuthService _authService;

    public AuthController(AuthService authService)
    {
      _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto registerDto)
    {
      var result = await _authService.RegisterAsync(registerDto);
      if (result.Succeeded)
        return Ok("User registered successfully.");
      return BadRequest(result.Errors);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto loginDto)
    {
      var token = await _authService.LoginAsync(loginDto);
      if (token != null)
        return Ok(token);
      return Unauthorized("Invalid credentials.");
    }
  }
}
