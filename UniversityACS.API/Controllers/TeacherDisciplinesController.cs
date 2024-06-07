using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.TeacherDisciplineServices;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.TeacherDisciplines.Base)]
public class TeacherDisciplinesController : ControllerBase
{
    private readonly ITeacherDisciplineService _teacherDisciplineService;

    public TeacherDisciplinesController(ITeacherDisciplineService teacherDisciplineService)
    {
        _teacherDisciplineService = teacherDisciplineService;
    }
    
    [HttpPost(ApiEndpoints.TeacherDisciplines.UpsertDisciplinesToTeacher)]
    public async Task<IActionResult> UpsertDisciplinesToTeacher(TeacherDisciplinesDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _teacherDisciplineService.UpsertDisciplinesToTeacherAsync(dto, cancellationToken);
        if(response.Success) return Ok(response);
        return BadRequest(response);
    }

    [HttpDelete(ApiEndpoints.TeacherDisciplines.DeleteDisciplinesFromTeacher)]
    public async Task<IActionResult> DeleteDisciplinesFromTeacher(TeacherDisciplinesDto dto,
        CancellationToken cancellationToken)
    {
        var response = await _teacherDisciplineService.DeleteDisciplinesFromTeacherAsync(dto, cancellationToken);
        if(response.Success) return Ok(response);
        return BadRequest(response);
    }
}