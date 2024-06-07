﻿using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DepartmentMeetingPlanServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.DepartmentMeetingPlans.Base)]
public class DepartmentMeetingPlansController : ControllerBase
{
    private readonly IDepartmentMeetingPlanService _meetingPlanService;

    public DepartmentMeetingPlansController(IDepartmentMeetingPlanService meetingPlanService)
    {
        _meetingPlanService = meetingPlanService;
    }
    
    [HttpPost(ApiEndpoints.DepartmentMeetingPlans.Create)]
    public async Task<ActionResult<CreateResponseDto<DepartmentMeetingPlanDto>>> CreateAsync(
        DepartmentMeetingPlanDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.DepartmentMeetingPlans.Update)]
    public async Task<ActionResult<UpdateResponseDto<DepartmentMeetingPlanDto>>> UpdateAsync(Guid id,
        DepartmentMeetingPlanDto dto, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.DepartmentMeetingPlans.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.DepartmentMeetingPlans.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DepartmentMeetingPlanResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.DepartmentMeetingPlans.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<DepartmentMeetingPlanResponseDto>>> GetByDepartmentIdAsync(
        Guid departmentId, CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.DepartmentMeetingPlans.GetAll)]
    public async Task<ActionResult<ListResponseDto<DepartmentMeetingPlanResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _meetingPlanService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}