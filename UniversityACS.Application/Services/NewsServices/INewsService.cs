using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.NewsServices;

public interface INewsService
{
    Task<CreateResponseDto<NewsDto>> CreateAsync(NewsDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<NewsDto>> UpdateAsync(Guid id, NewsDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<NewsDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<NewsDto>> GetAllAsync(CancellationToken cancellationToken = default!);

    Task<ListResponseDto<NewsDto>> GetByDepartmentIdAsync(Guid departmentId,
        CancellationToken cancellationToken = default!);

    Task<ListResponseDto<NewsDto>> GetStudyPartNewsAsync(CancellationToken cancellationToken = default!);
}