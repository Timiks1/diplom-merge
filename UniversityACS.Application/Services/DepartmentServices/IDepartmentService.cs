using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.DepartmentServices;

public interface IDepartmentService
{
    Task<CreateResponseDto<DepartmentDto>> CreateAsync(DepartmentDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<DepartmentDto>> UpdateAsync(Guid id, DepartmentDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<DepartmentDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<DepartmentDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}