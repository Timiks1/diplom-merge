using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.NewsServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.News.Base)]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
    }
    
    [HttpPost(ApiEndpoints.News.Create)]
    public async Task<ActionResult<CreateResponseDto<NewsDto>>> CreateAsync(NewsDto dto, CancellationToken cancellationToken)
    {
        var response = await _newsService.CreateAsync(dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpDelete(ApiEndpoints.News.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _newsService.DeleteAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpPut(ApiEndpoints.News.Update)]
    public async Task<ActionResult<UpdateResponseDto<NewsDto>>> UpdateAsync(Guid id, NewsDto dto, CancellationToken cancellationToken)
    {
        var response = await _newsService.UpdateAsync(id, dto, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.News.GetById)]
    public async Task<ActionResult<DetailsResponseDto<NewsDto>>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _newsService.GetByIdAsync(id, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.News.GetAll)]
    public async Task<ActionResult<ListResponseDto<NewsDto>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = await _newsService.GetAllAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.News.GetByDepartmentId)]
    public async Task<ActionResult<ListResponseDto<NewsDto>>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var response = await _newsService.GetByDepartmentIdAsync(departmentId, cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
    
    [HttpGet(ApiEndpoints.News.GetStudyPartNews)]
    public async Task<IActionResult> GetStudyPartNewsAsync(CancellationToken cancellationToken)
    {
        var response = await _newsService.GetStudyPartNewsAsync(cancellationToken);
        if (response.Success) return Ok(response);
        return BadRequest(response);
    }
}