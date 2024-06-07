using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Services.Identity;

public interface IIdentityService
{
    Task<LoginResponseDto> Login(LoginRequestDto requestDto, CancellationToken cancellationToken);
    Task<DetailsResponseDto<ApplicationUserResponseDto>> GetCurrentUser(CancellationToken cancellationToken);
}