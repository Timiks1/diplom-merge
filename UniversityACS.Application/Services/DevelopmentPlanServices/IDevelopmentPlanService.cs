using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.DevelopmentPlanServices;

public interface IDevelopmentPlanService
{
    Task<CreateResponseDto<DevelopmentPlanDto>> CreateAsync(DevelopmentPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<DevelopmentPlanDto>> UpdateAsync(Guid id, DevelopmentPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<DevelopmentPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DevelopmentPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DevelopmentPlanResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}