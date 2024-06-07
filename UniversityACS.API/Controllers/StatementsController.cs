using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.StatementServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Statements.Base)]
public class StatementsController : ControllerBase
{
    private readonly IStatementService _statementService;

    public StatementsController(IStatementService statementService)
    {
        _statementService = statementService;
    }
    
    [HttpPost(ApiEndpoints.Statements.Create)]
    public async Task<ActionResult<CreateResponseDto<StatementResponseDto>>> CreateAsync(StatementDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _statementService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.Statements.Update)]
    public async Task<ActionResult<UpdateResponseDto<StatementResponseDto>>> UpdateAsync(Guid id, StatementDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _statementService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.Statements.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _statementService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Statements.GetById)]
    public async Task<ActionResult<DetailsResponseDto<StatementResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _statementService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Statements.GetBySubject)]
    public async Task<ActionResult<ListResponseDto<StatementResponseDto>>> GetBySubjectAsync(string subject,
        CancellationToken cancellationToken)
    {
        var response = await _statementService.GetBySubjectAsync(subject, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Statements.GetAll)]
    public async Task<ActionResult<ListResponseDto<StatementResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _statementService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}