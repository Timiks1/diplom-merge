using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ApplicationUserServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Users.Base)]
public class ApplicationUsersController : ControllerBase
{
    private readonly IApplicationUserService _applicationUserService;

    public ApplicationUsersController(IApplicationUserService applicationUserService)
    {
        _applicationUserService = applicationUserService;
    }

    [HttpPost(ApiEndpoints.Users.Create)]
    public async Task<ActionResult<CreateResponseDto<ApplicationUserDto>>> CreateAsync(ApplicationUserDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.CreateAsync(dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPut(ApiEndpoints.Users.Update)]
    public async Task<ActionResult<UpdateResponseDto<ApplicationUserDto>>> UpdateAsync(Guid id, ApplicationUserDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.UpdateAsync(id, dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpDelete(ApiEndpoints.Users.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.DeleteAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Users.GetById)]
    public async Task<ActionResult<DetailsResponseDto<ApplicationUserDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.GetByIdAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Users.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<ApplicationUserDto>>> GetByDepartmentIdAsync(Guid departmentId,
        CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Users.GetAll)]
    public async Task<ActionResult<ListResponseDto<ApplicationUserDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.GetAllAsync(cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPost(ApiEndpoints.Users.ChangePassword)]
    public async Task<ActionResult<ResponseDto>> ChangePasswordAsync(ChangePasswordDto changePasswordDto, 
        CancellationToken cancellationToken)
    {
        var response =
            await _applicationUserService.ChangePasswordAsync(changePasswordDto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPut(ApiEndpoints.Users.UpdateUserRolesAsync)]
    public async Task<ActionResult<ResponseDto>> UpdateUserRolesAsync(UpdateUserRolesDto requestDto,
        CancellationToken cancellationToken)
    {
        var response = await _applicationUserService.UpdateUserRolesAsync(requestDto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}