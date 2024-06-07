using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DisciplineServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Disciplines.Base)]
public class DisciplinesController : ControllerBase
{
    private readonly IDisciplineService _disciplineService;

    public DisciplinesController(IDisciplineService disciplineService)
    {
        _disciplineService = disciplineService;
    }
    
    [HttpPost(ApiEndpoints.Disciplines.Create)]
    public async Task<ActionResult<CreateResponseDto<DisciplineDto>>> CreateAsync(DisciplineDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _disciplineService.CreateAsync(dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPut(ApiEndpoints.Disciplines.Update)]
    public async Task<ActionResult<UpdateResponseDto<DisciplineDto>>> UpdateAsync(Guid id, DisciplineDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _disciplineService.UpdateAsync(id, dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpDelete(ApiEndpoints.Disciplines.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _disciplineService.DeleteAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Disciplines.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DisciplineDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _disciplineService.GetByIdAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Disciplines.GetAll)]
    public async Task<ActionResult<ListResponseDto<DisciplineDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _disciplineService.GetAllAsync(cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpGet(ApiEndpoints.Disciplines.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<DisciplineDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken = default)
    {
        var response = await _disciplineService.GetByUserIdAsync(userId, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}