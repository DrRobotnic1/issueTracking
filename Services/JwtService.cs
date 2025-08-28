using API.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
  public class JwtService
  {
    private readonly IConfiguration _configuration;
    private readonly SymmetricSecurityKey _key;

    public JwtService(IConfiguration configuration)
    {
      _configuration = configuration;
      _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
    }

    public string GenerateToken(User user)
    {
      var claims = new[]
      {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Email, user.Email)
        };

      var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
      var token = new JwtSecurityToken(
          issuer: _configuration["Jwt:Issuer"],
          audience: _configuration["Jwt:Audience"],
          claims: claims,
          expires: DateTime.Now.AddHours(1),
          signingCredentials: credentials
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
