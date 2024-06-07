using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.SubmissionToCertificationThemesServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.SubmissionToCertificationThemes.Base)]
public class SubmissionToCertificationThemesController : ControllerBase
{
    private readonly ISubmissionToCertificationThemesService _certificationThemesService;

    public SubmissionToCertificationThemesController(ISubmissionToCertificationThemesService certificationThemesService)
    {
        _certificationThemesService = certificationThemesService;
    }
    
    [HttpPost(ApiEndpoints.SubmissionToCertificationThemes.Create)]
    public async Task<ActionResult<CreateResponseDto<SubmissionToCertificationThemesResponseDto>>> CreateAsync(
        SubmissionToCertificationThemesDto dto, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.SubmissionToCertificationThemes.Update)]
    public async Task<ActionResult<UpdateResponseDto<SubmissionToCertificationThemesResponseDto>>> UpdateAsync(Guid id,
        SubmissionToCertificationThemesDto dto, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.SubmissionToCertificationThemes.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.SubmissionToCertificationThemes.GetById)]
    public async Task<ActionResult<DetailsResponseDto<SubmissionToCertificationThemesResponseDto>>> GetByIdAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpGet(ApiEndpoints.SubmissionToCertificationThemes.GetAll)]
    public async Task<ActionResult<ListResponseDto<SubmissionToCertificationThemesResponseDto>>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var response = await _certificationThemesService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}