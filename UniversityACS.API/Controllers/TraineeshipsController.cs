using Microsoft.AspNetCore.Mvc;
using UniversityACS.API.Endpoints;
using UniversityACS.Application.Services.TraineeshipServices;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.API.Controllers;

[ApiController]
[Route(ApiEndpoints.Traineeships.Base)]
public class TraineeshipsController : ControllerBase
{
    private readonly ITraineeshipService _traineeshipService;

    public TraineeshipsController(ITraineeshipService traineeshipService)
    {
        _traineeshipService = traineeshipService;
    }
    
    [HttpPost(ApiEndpoints.Traineeships.Create)]
    public async Task<ActionResult<CreateResponseDto<TraineeshipDto>>> CreateAsync(TraineeshipDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _traineeshipService.CreateAsync(dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPut(ApiEndpoints.Traineeships.Update)]
    public async Task<ActionResult<UpdateResponseDto<TraineeshipDto>>> UpdateAsync(Guid id, TraineeshipDto dto,
        CancellationToken cancellationToken = default)
    {
        var response = await _traineeshipService.UpdateAsync(id, dto, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpDelete(ApiEndpoints.Traineeships.Delete)]
    public async Task<ActionResult<ResponseDto>> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var response = await _traineeshipService.DeleteAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Traineeships.GetById)]
    public async Task<ActionResult<DetailsResponseDto<TraineeshipDto>>> GetByIdAsync(Guid id,
        CancellationToken cancellationToken = default)
    {
        var response = await _traineeshipService.GetByIdAsync(id, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Traineeships.GetAll)]
    public async Task<ActionResult<ListResponseDto<TraineeshipDto>>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var response = await _traineeshipService.GetAllAsync(cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpGet(ApiEndpoints.Traineeships.GetByUserId)]
    public async Task<ActionResult<ListResponseDto<TraineeshipDto>>> GetByUserIdAsync(Guid userId,
        CancellationToken cancellationToken)
    {
        var response = await _traineeshipService.GetByUserIdAsync(userId, cancellationToken);
        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}