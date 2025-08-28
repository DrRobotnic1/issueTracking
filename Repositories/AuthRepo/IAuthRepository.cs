using API.Dtos.Auth;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.AuthRepo
{
  public interface IAuthRepository
  {
    Task<IdentityResult> RegisterAsync(RegisterDto registerDto);
    Task<User> LoginAsync(LoginDto loginDto);
  }
}
