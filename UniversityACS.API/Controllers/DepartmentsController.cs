using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.DepartmentServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Departments.Base)]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }
    
    [HttpPost(ApiEndpoints.Departments.Create)]
    public async Task<ActionResult<CreateResponseDto<DepartmentDto>>> CreateAsync(DepartmentDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _departmentService.CreateAsync(dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPut(ApiEndpoints.Departments.Update)]
    public async Task<ActionResult<UpdateResponseDto<DepartmentDto>>> UpdateAsync(Guid id, DepartmentDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _departmentService.UpdateAsync(id, dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpDelete(ApiEndpoints.Departments.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _departmentService.DeleteAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Departments.GetById)]
    public async Task<ActionResult<DetailsResponseDto<DepartmentDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _departmentService.GetByIdAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Departments.GetAll)]
    public async Task<ActionResult<ListResponseDto<DepartmentDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _departmentService.GetAllAsync(cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}