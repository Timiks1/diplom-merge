using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.SubmissionToTheCommitteeServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.SubmissionToCommittees.Base)]
public class SubmissionToCommitteesController : ControllerBase
{
    private readonly ISubmissionToTheCommitteeService _committeeService;

    public SubmissionToCommitteesController(ISubmissionToTheCommitteeService committeeService)
    {
        _committeeService = committeeService;
    }
    
    [HttpPost(ApiEndpoints.SubmissionToCommittees.Create)]
    public async Task<ActionResult<CreateResponseDto<SubmissionToTheCommitteeResponseDto>>> CreateAsync(
        SubmissionToTheCommitteeDto dto, CancellationToken cancellationToken)
    {
        var response = await _committeeService.CreateAsync(dto, cancellationToken);
        if(response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.SubmissionToCommittees.Update)]
    public async Task<ActionResult<UpdateResponseDto<SubmissionToTheCommitteeResponseDto>>> UpdateAsync(Guid id,
        SubmissionToTheCommitteeDto dto, CancellationToken cancellationToken)
    {
        var response = await _committeeService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.SubmissionToCommittees.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _committeeService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.SubmissionToCommittees.GetById)]
    public async Task<ActionResult<DetailsResponseDto<SubmissionToTheCommitteeResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _committeeService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.SubmissionToCommittees.GetAll)]
    public async Task<ActionResult<ListResponseDto<SubmissionToTheCommitteeResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _committeeService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}