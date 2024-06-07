using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.SubmissionToCertificationThemesServices;

public interface ISubmissionToCertificationThemesService
{
    Task<CreateResponseDto<SubmissionToCertificationThemesDto>> CreateAsync(SubmissionToCertificationThemesDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<SubmissionToCertificationThemesDto>> UpdateAsync(Guid id, SubmissionToCertificationThemesDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<SubmissionToCertificationThemesResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SubmissionToCertificationThemesResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}