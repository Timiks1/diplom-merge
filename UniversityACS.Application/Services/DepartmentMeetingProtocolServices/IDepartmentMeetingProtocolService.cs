using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.DepartmentMeetingProtocolServices;

public interface IDepartmentMeetingProtocolService
{
    Task<CreateResponseDto<DepartmentMeetingProtocolDto>> CreateAsync(DepartmentMeetingProtocolDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<DepartmentMeetingProtocolDto>> UpdateAsync(Guid id, DepartmentMeetingProtocolDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<DepartmentMeetingProtocolResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DepartmentMeetingProtocolResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DepartmentMeetingProtocolResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default!);
}