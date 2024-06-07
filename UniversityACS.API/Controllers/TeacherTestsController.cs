using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.TeacherTestServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.TeacherTests.Base)]
public class TeacherTestsController : ControllerBase
{
    private readonly ITeacherTestService _teacherTestService;

    public TeacherTestsController(ITeacherTestService teacherTestService)
    {
        _teacherTestService = teacherTestService;
    }
    
    [HttpPost(ApiEndpoints.TeacherTests.Create)]
    public async Task<ActionResult<CreateResponseDto<TeacherTestDto>>> CreateAsync(TeacherTestDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _teacherTestService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpPut(ApiEndpoints.TeacherTests.Update)]
    public async Task<ActionResult<UpdateResponseDto<TeacherTestDto>>> UpdateAsync(Guid id, TeacherTestDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _teacherTestService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.TeacherTests.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _teacherTestService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.TeacherTests.GetById)]
    public async Task<ActionResult<DetailsResponseDto<TeacherTestDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken)
    {
        var response = await _teacherTestService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.TeacherTests.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<TeacherTestDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _teacherTestService.GetByUserIdAsync(userId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.TeacherTests.GetAll)]
    public async Task<ActionResult<ListResponseDto<TeacherTestDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _teacherTestService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}