using API.Dtos.Auth;
using API.Repositories.AuthRepo;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
  public class AuthService
  {
    private readonly IAuthRepository _authRepository;
    private readonly JwtService _jwtService;

    public AuthService(IAuthRepository authRepository, JwtService jwtService)
    {
      _authRepository = authRepository;
      _jwtService = jwtService;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
    {
      return await _authRepository.RegisterAsync(registerDto);
    }

    public async Task<TokenDto> LoginAsync(LoginDto loginDto)
    {
      var user = await _authRepository.LoginAsync(loginDto);
      if (user != null)
      {
        var token = _jwtService.GenerateToken(user);
        return new TokenDto { Token = token };
      }
      return null;
    }
  }
}
