using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.ExchangeVisitPlanServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.ExchangeVisitsPlans.Base)]
public class ExchangeVisitsPlansController : ControllerBase
{
    private readonly IExchangeVisitPlanService _exchangeVisitPlanService;

    public ExchangeVisitsPlansController(IExchangeVisitPlanService exchangeVisitPlanService)
    {
        _exchangeVisitPlanService = exchangeVisitPlanService;
    }

    [HttpPost(ApiEndpoints.ExchangeVisitsPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<ExchangeVisitsPlanResponseDto>>> CreateAsync(
        ExchangeVisitsPlanDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.ExchangeVisitsPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<ExchangeVisitsPlanResponseDto>>> UpdateAsync(Guid id,
        ExchangeVisitsPlanDto dto, CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.ExchangeVisitsPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ExchangeVisitsPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<ExchangeVisitsPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ExchangeVisitsPlans.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<ExchangeVisitsPlanResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.ExchangeVisitsPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<ExchangeVisitsPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _exchangeVisitPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}