using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.SubmissionToTheHeadOfCommitteeServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.SubmissionToTheHeadOfCommittees.Base)]
public class SubmissionToTheHeadOfCommitteesController : ControllerBase
{
    private readonly ISubmissionToTheHeadOfCommitteeService _headOfCommitteeService;

    public SubmissionToTheHeadOfCommitteesController(ISubmissionToTheHeadOfCommitteeService headOfCommitteeService)
    {
        _headOfCommitteeService = headOfCommitteeService;
    }
    
    [HttpPost(ApiEndpoints.SubmissionToTheHeadOfCommittees.Create)]
    public async Task<ActionResult<CreateResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>>> CreateAsync(
        SubmissionToTheHeadOfCommitteeDto dto, CancellationToken cancellationToken)
    {
        var response = await _headOfCommitteeService.CreateAsync(dto, cancellationToken);
        if(response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.SubmissionToTheHeadOfCommittees.Update)]
    public async Task<ActionResult<UpdateResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>>> UpdateAsync(Guid id,
        SubmissionToTheHeadOfCommitteeDto dto, CancellationToken cancellationToken)
    {
        var response = await _headOfCommitteeService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.SubmissionToTheHeadOfCommittees.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _headOfCommitteeService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.SubmissionToTheHeadOfCommittees.GetById)]
    public async Task<ActionResult<DetailsResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _headOfCommitteeService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.SubmissionToTheHeadOfCommittees.GetAll)]
    public async Task<ActionResult<ListResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _headOfCommitteeService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}