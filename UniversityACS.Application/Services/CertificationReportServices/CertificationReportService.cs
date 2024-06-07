using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.CertificationReportServices;

public class CertificationReportService : ICertificationReportService
{
    private readonly ApplicationDbContext _context;

    public CertificationReportService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<CertificationReportDto>> CreateAsync(CertificationReportDto dto, CancellationToken cancellationToken)
    {
        var entity = new CertificationReport()
        {
            Id = dto.Id,
            Name = dto.Name
        };

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.CertificationReports.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<CertificationReportDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<CertificationReportDto>> UpdateAsync(Guid id, CertificationReportDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.CertificationReports
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<CertificationReportDto>()
            {
                Success = false,
                ErrorMessage = "Certification report not found."
            };
        }

        existingEntity.Name = dto.Name;
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }
        
        _context.CertificationReports.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<CertificationReportDto>() { Success = true, Id = existingEntity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.CertificationReports
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "Certification report not found."
            };
        }
        
        _context.CertificationReports.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<CertificationReportResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.CertificationReports
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<CertificationReportResponseDto>()
            {
                Success = false,
                ErrorMessage = "Certification report not found."
            };
        }

        return new DetailsResponseDto<CertificationReportResponseDto>()
        {
            Success = true,
            Item = new CertificationReportResponseDto()
            {
                Id = existingEntity.Id, Name = existingEntity.Name, File = existingEntity.File
            }
        };
    }

    public async Task<ListResponseDto<CertificationReportResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.CertificationReports
            .ToListAsync(cancellationToken);

        return new ListResponseDto<CertificationReportResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => new CertificationReportResponseDto()
                {
                    Id = x.Id, Name = x.Name, File = x.File
                })
                .ToList(),
            TotalCount = entities.Count
        };
    }
}