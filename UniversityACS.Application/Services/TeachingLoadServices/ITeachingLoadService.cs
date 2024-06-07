using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.TeachingLoadServices;

public interface ITeachingLoadService
{
    Task<CreateResponseDto<TeachingLoadDto>> CreateAsync(TeachingLoadDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<TeachingLoadDto>> UpdateAsync(Guid id, TeachingLoadDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<TeachingLoadResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<TeachingLoadResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<TeachingLoadResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}