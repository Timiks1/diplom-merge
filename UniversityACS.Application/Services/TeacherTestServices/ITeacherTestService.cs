using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.TeacherTestServices;

public interface ITeacherTestService
{
    Task<CreateResponseDto<TeacherTestDto>> CreateAsync(TeacherTestDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<TeacherTestDto>> UpdateAsync(Guid id, TeacherTestDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<TeacherTestDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<TeacherTestDto>> GetAllAsync(CancellationToken cancellationToken = default!);
    Task<ListResponseDto<TeacherTestDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default!);
}