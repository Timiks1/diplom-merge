using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Extensions;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.API.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly IConfiguration _configuration;
    private readonly TokenService _tokenService;
    private readonly ILogger<IdentityService> _logger;
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IdentityService(UserManager<ApplicationUser> userManager, 
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        TokenService tokenService,
        ILogger<IdentityService> logger,
        ApplicationDbContext context,
        IHttpContextAccessor httpContextAccessor)
    {
        _signInManager = signInManager;
        _configuration = configuration;
        _tokenService = tokenService;
        _logger = logger;
        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task<LoginResponseDto> Login(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        var existingUser = await _context.ApplicationUsers
            .FirstOrDefaultAsync(x => x.UserName == requestDto.UserName, cancellationToken);
        if (existingUser == null) return CreateUnauthorizedLoginResponse();

        if (existingUser.LockoutEnabled)
        {
            _logger.LogInformation("Logging in user {userName} 3", requestDto.UserName);
            if (_logger.IsEnabled(LogLevel.Warning))
                _logger.LogWarning("Attempted to login with locked user. User {userName}",
                    existingUser.UserName);

            return CreateUnauthorizedLoginResponse();
        }
        
        var result = await _signInManager.PasswordSignInAsync(existingUser, requestDto.Password, false, false);

        if (!result.Succeeded) return CreateUnauthorizedLoginResponse();
        return await _tokenService.BuildToken(existingUser);
    }

    public async Task<DetailsResponseDto<ApplicationUserResponseDto>> GetCurrentUser(CancellationToken cancellationToken)
    {
        var user = await _httpContextAccessor.HttpContext.GetUserFromContextAsync(_context, cancellationToken);

        return new DetailsResponseDto<ApplicationUserResponseDto>()
        {
            Success = true,
            Item = user.ToDto(),
        };
    }
    
    private static LoginResponseDto CreateUnauthorizedLoginResponse()
    {
        return new LoginResponseDto
        {
            Success = false
        };
    }
}