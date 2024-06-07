using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.IndividualPlanServices;

public interface IIndividualPlanService
{
    Task<CreateResponseDto<IndividualPlanDto>> CreateAsync(IndividualPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<IndividualPlanDto>> UpdateAsync(Guid id, IndividualPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<IndividualPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<IndividualPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<IndividualPlanResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}