using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.DepartmentMeetingPlanServices;

public interface IDepartmentMeetingPlanService
{
    Task<CreateResponseDto<DepartmentMeetingPlanDto>> CreateAsync(DepartmentMeetingPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<DepartmentMeetingPlanDto>> UpdateAsync(Guid id, DepartmentMeetingPlanDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<DepartmentMeetingPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DepartmentMeetingPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DepartmentMeetingPlanResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default!);
}