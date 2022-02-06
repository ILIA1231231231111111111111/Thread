using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Thread.Core.Conts;
using Thread.Core.Entities;
using Thread.Interfaces.Identity;

#nullable enable

namespace Thread.Services;

public class TokenClaimsService : ITokenClaimsService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenClaimsService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<string> GenerateTokenAsync(string? userName)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(AuthorizationConstants.JWT_SECRET_KEY);
        var user = await _userManager.FindByNameAsync(userName);
        var claims = new List<Claim>
        {
            new Claim("IdentityId", user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(AuthorizationConstants.TOKEN_LIFE_TIME_IN_DAYS),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}   