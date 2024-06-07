using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;

namespace UniversityACS.Application.Services.CertificationReportServices;

public interface ICertificationReportService
{
    Task<CreateResponseDto<CertificationReportDto>> CreateAsync(CertificationReportDto dto,
        CancellationToken cancellationToken = default!);
    Task<UpdateResponseDto<CertificationReportDto>> UpdateAsync(Guid id, CertificationReportDto dto,
        CancellationToken cancellationToken = default!);
    Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<DetailsResponseDto<CertificationReportResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default!);
    Task<ListResponseDto<CertificationReportResponseDto>> GetAllAsync(CancellationToken cancellationToken = default!);
}