using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.IndividualPlanServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.IndividualPlans.Base)]
public class IndividualPlansController : ControllerBase
{
    private readonly IIndividualPlanService _individualPlanService;

    public IndividualPlansController(IIndividualPlanService individualPlanService)
    {
        _individualPlanService = individualPlanService;
    }

    [HttpPost(ApiEndpoints.IndividualPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<IndividualPlanResponseDto>>> CreateAsync(IndividualPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.IndividualPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<IndividualPlanResponseDto>>> UpdateAsync(Guid id, 
        IndividualPlanDto dto, CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.IndividualPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.IndividualPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<IndividualPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.IndividualPlans.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<IndividualPlanResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.IndividualPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<IndividualPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _individualPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}