using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.ExchangeVisitPlanServices;

public interface IExchangeVisitPlanService
{
    Task<CreateResponseDto<ExchangeVisitsPlanDto>> CreateAsync(ExchangeVisitsPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<ExchangeVisitsPlanDto>> UpdateAsync(Guid id, ExchangeVisitsPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<ExchangeVisitsPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ExchangeVisitsPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ExchangeVisitsPlanResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}