using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.CurriculumServices;

public interface ICurriculumService
{
    Task<CreateResponseDto<CurriculumDto>> CreateAsync(CurriculumDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<CurriculumDto>> UpdateAsync(Guid id, CurriculumDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<CurriculumResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<CurriculumResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<CurriculumResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}