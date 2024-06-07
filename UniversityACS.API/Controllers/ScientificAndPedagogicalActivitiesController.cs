using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.ScientificAndPedagogicalActivities.Base)]
public class ScientificAndPedagogicalActivitiesController : ControllerBase
{
    private readonly IScientificAndPedagogicalActivityService _activityService;

    public ScientificAndPedagogicalActivitiesController(IScientificAndPedagogicalActivityService activityService)
    {
        _activityService = activityService;
    }

    [HttpPost(ApiEndpoints.ScientificAndPedagogicalActivities.Create)]
    public async Task<ActionResult<CreateResponseDto<ScientificAndPedagogicalActivityDto>>> CreateAsync(
        ScientificAndPedagogicalActivityDto dto, CancellationToken cancellationToken)
    {
        var response = await _activityService.CreateAsync(dto, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.ScientificAndPedagogicalActivities.Update)]
    public async Task<ActionResult<UpdateResponseDto<ScientificAndPedagogicalActivityDto>>> UpdateAsync(Guid id,
        ScientificAndPedagogicalActivityDto dto, CancellationToken cancellationToken)
    {
        var response = await _activityService.UpdateAsync(id, dto, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.ScientificAndPedagogicalActivities.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _activityService.DeleteAsync(id, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.ScientificAndPedagogicalActivities.GetById)]
    public async Task<ActionResult<DetailsResponseDto<ScientificAndPedagogicalActivityDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _activityService.GetByIdAsync(id, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.ScientificAndPedagogicalActivities.GetAll)]
    public async Task<ActionResult<ListResponseDto<ScientificAndPedagogicalActivityDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _activityService.GetAllAsync(cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ScientificAndPedagogicalActivities.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<ScientificAndPedagogicalActivityDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _activityService.GetByUserIdAsync(userId, cancellationToken);
        return response.Success ? Ok(response) : BadRequest(response);
    }
}