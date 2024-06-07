using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.API.Services.Identity;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Identity.Base)]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    
    [HttpPost(ApiEndpoints.Identity.Login)]
    public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto requestDto, CancellationToken cancellationToken)
    {
        var response = await _identityService.Login(requestDto, cancellationToken);
        if(response.Success) return Ok(response);
        return Unauthorized(response);
    }
    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [HttpGet(ApiEndpoints.Identity.GetCurrentUser)]
    public async Task<ActionResult<DetailsResponseDto<ApplicationUserResponseDto>>> GetCurrentUser(CancellationToken cancellationToken)
    {
        var response = await _identityService.GetCurrentUser(cancellationToken);
        if(response.Success) return Ok(response);
        return BadRequest(response);
    }
}