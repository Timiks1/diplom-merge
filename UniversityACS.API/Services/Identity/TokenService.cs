using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.API.Services.Identity;

public class TokenService
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;

    public TokenService(UserManager<ApplicationUser> userManager, IConfiguration configuration,
        ApplicationDbContext context)
    {
        _userManager = userManager;
        _configuration = configuration;
        _context = context;
    }

    public async Task<LoginResponseDto> BuildToken(ApplicationUser userInfo)
    {
        var claims = new List<Claim>
        {
            new("UserName", userInfo.UserName),
            new("Email", string.IsNullOrEmpty(userInfo.Email) ? "" : userInfo.Email)
        };

        var roles = await _userManager.GetRolesAsync(userInfo);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var identityUser = await _context.ApplicationUsers.FirstOrDefaultAsync(x=>x.UserName == userInfo.UserName);
        var claimsDb = await _userManager.GetClaimsAsync(identityUser);

        claims.AddRange(claimsDb);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expiration = DateTime.UtcNow.AddDays(1);

        var token = new JwtSecurityToken(
            null,
            null,
            claims,
            expires: expiration,
            signingCredentials: credentials);

        return new LoginResponseDto
        {
            Success = true,
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration.ToUniversalTime().ToString("u")
        };
    }
}