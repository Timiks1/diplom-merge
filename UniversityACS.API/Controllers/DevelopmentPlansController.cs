using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DevelopmentPlanServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.DevelopmentPlans.Base)]
public class DevelopmentPlansController : ControllerBase
{
    private readonly IDevelopmentPlanService _developmentPlanService;

    public DevelopmentPlansController(IDevelopmentPlanService developmentPlanService)
    {
        _developmentPlanService = developmentPlanService;
    }

    [HttpPost(ApiEndpoints.DevelopmentPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<DevelopmentPlanResponseDto>>> CreateAsync(DevelopmentPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.DevelopmentPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<DevelopmentPlanResponseDto>>> UpdateAsync(Guid id, DevelopmentPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.DevelopmentPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _developmentPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.DevelopmentPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DevelopmentPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _developmentPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DevelopmentPlans.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<DevelopmentPlanResponseDto>>> GetByUserIdAsync(
        Guid userId, CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.DevelopmentPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<DevelopmentPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _developmentPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}