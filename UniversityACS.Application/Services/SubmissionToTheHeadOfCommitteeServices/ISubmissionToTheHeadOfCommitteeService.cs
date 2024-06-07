using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.SubmissionToTheHeadOfCommitteeServices;

public interface ISubmissionToTheHeadOfCommitteeService
{
    Task<CreateResponseDto<SubmissionToTheHeadOfCommitteeDto>> CreateAsync(SubmissionToTheHeadOfCommitteeDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<SubmissionToTheHeadOfCommitteeDto>> UpdateAsync(Guid id, SubmissionToTheHeadOfCommitteeDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}