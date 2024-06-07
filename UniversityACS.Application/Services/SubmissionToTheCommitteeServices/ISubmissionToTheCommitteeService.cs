using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.SubmissionToTheCommitteeServices;

public interface ISubmissionToTheCommitteeService
{
    Task<CreateResponseDto<SubmissionToTheCommitteeDto>> CreateAsync(SubmissionToTheCommitteeDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<SubmissionToTheCommitteeDto>> UpdateAsync(Guid id, SubmissionToTheCommitteeDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<SubmissionToTheCommitteeResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SubmissionToTheCommitteeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}