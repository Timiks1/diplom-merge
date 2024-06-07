using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.CurriculumServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Curricula.Base)]
public class CurriculaController : ControllerBase
{
    private readonly ICurriculumService _curriculumService;

    public CurriculaController(ICurriculumService curriculumService)
    {
        _curriculumService = curriculumService;
    }
    
    [HttpPost(ApiEndpoints.Curricula.Create)]
    public async Task<ActionResult<CreateResponseDto<CurriculumDto>>> CreateAsync(CurriculumDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.Curricula.Update)]
    public async Task<ActionResult<UpdateResponseDto<CurriculumDto>>> UpdateAsync(Guid id, CurriculumDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.Curricula.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Curricula.GetById)]
    public async Task<ActionResult<DetailsResponseDto<CurriculumResponseDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Curricula.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<CurriculumResponseDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.Curricula.GetAll)]
    public async Task<ActionResult<ListResponseDto<CurriculumResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _curriculumService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}