using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Services.ApplicationUserServices;

public interface IApplicationUserService
{
    Task<CreateResponseDto<ApplicationUserResponseDto>> CreateAsync(ApplicationUserDto dto, CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<ApplicationUserResponseDto>> UpdateAsync(Guid id, ApplicationUserDto dto, CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<ApplicationUserResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ApplicationUserResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<ApplicationUserResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken = default!);
    Task<ResponseDto> ChangePasswordAsync(ChangePasswordDto changePasswordDto, CancellationToken cancellationToken = default!);
    Task<ResponseDto> UpdateUserRolesAsync(UpdateUserRolesDto requestDto, CancellationToken cancellationToken = default!);
}