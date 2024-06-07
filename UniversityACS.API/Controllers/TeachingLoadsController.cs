using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.TeachingLoadServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.TeacherLoads.Base)]
public class TeachingLoadsController : ControllerBase
{
    private readonly ITeachingLoadService _teachingLoadService;

    public TeachingLoadsController(ITeachingLoadService teachingLoadService)
    {
        _teachingLoadService = teachingLoadService;
    }
    
    [HttpPost(ApiEndpoints.TeacherLoads.Create)]
    public async Task<ActionResult<CreateResponseDto<TeachingLoadResponseDto>>> CreateAsync(TeachingLoadDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.TeacherLoads.Update)]
    public async Task<ActionResult<UpdateResponseDto<TeachingLoadResponseDto>>> UpdateAsync(Guid id,
        TeachingLoadDto dto, CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.TeacherLoads.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.TeacherLoads.GetById)]
    public async Task<ActionResult<DetailsResponseDto<TeachingLoadResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.TeacherLoads.GetAll)]
    public async Task<ActionResult<ListResponseDto<TeachingLoadResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.TeacherLoads.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<TeachingLoadResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _teachingLoadService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}