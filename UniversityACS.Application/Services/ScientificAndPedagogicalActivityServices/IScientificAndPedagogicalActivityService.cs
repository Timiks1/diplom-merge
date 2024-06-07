using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;

public interface IScientificAndPedagogicalActivityService
{
    Task<CreateResponseDto<ScientificAndPedagogicalActivityDto>> CreateAsync(ScientificAndPedagogicalActivityDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<ScientificAndPedagogicalActivityDto>> UpdateAsync(Guid id, ScientificAndPedagogicalActivityDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<ScientificAndPedagogicalActivityResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ScientificAndPedagogicalActivityResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ScientificAndPedagogicalActivityResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}