using API.Dtos.Auth;
using API.Models;
using Microsoft.AspNetCore.Identity;

namespace API.Repositories.AuthRepo
{
  public class AuthRepository:IAuthRepository
  {
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;

    public AuthRepository(UserManager<User> userManager, SignInManager<User> signInManager)
    {
      _userManager = userManager;
      _signInManager = signInManager;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterDto registerDto)
    {
      var user = new User { UserName = registerDto.UserName, Email = registerDto.Email };
      return await _userManager.CreateAsync(user, registerDto.Password);
    }

    public async Task<User> LoginAsync(LoginDto loginDto)
    {
      var user = await _userManager.FindByNameAsync(loginDto.UserName);
      if (user != null)
      {
        var result = await _signInManager.PasswordSignInAsync(user, loginDto.Password, false, false);
        if (result.Succeeded)
          return user;
      }
      return null;
    }
  }
}
