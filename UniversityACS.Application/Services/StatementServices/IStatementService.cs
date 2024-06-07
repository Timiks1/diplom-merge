using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.StatementServices;

public interface IStatementService
{
    Task<CreateResponseDto<StatementDto>> CreateAsync(StatementDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<StatementDto>> UpdateAsync(Guid id, StatementDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<StatementResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<StatementResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<StatementResponseDto>> GetBySubjectAsync(string subject, CancellationToken cancellationToken = default!);
}