using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.SubmissionToCertificationThemesServices;

public class SubmissionToCertificationThemesService : ISubmissionToCertificationThemesService
{
    private readonly ApplicationDbContext _context;

    public SubmissionToCertificationThemesService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<SubmissionToCertificationThemesDto>> CreateAsync(SubmissionToCertificationThemesDto dto, CancellationToken cancellationToken)
    {
        var entity = new SubmissionToCertificationThemes()
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

        await _context.SubmissionToCertificationThemes.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<SubmissionToCertificationThemesDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<SubmissionToCertificationThemesDto>> UpdateAsync(Guid id, SubmissionToCertificationThemesDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToCertificationThemes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<SubmissionToCertificationThemesDto>()
            {
                Success = false, ErrorMessage = "SubmissionToCertificationThemes not found"
            };
        }

        entity.Name = dto.Name;
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.SubmissionToCertificationThemes.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<SubmissionToCertificationThemesDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToCertificationThemes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "SubmissionToCertificationThemes not found"
            };
        }
        
        _context.SubmissionToCertificationThemes.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<SubmissionToCertificationThemesResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToCertificationThemes
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<SubmissionToCertificationThemesResponseDto>()
            {
                Success = false, ErrorMessage = "SubmissionToCertificationThemes not found"
            };
        }

        return new DetailsResponseDto<SubmissionToCertificationThemesResponseDto>()
        {
            Success = true,
            Item = new SubmissionToCertificationThemesResponseDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                File = entity.File
            }
        };
    }

    public async Task<ListResponseDto<SubmissionToCertificationThemesResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.SubmissionToCertificationThemes
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SubmissionToCertificationThemesResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => new SubmissionToCertificationThemesResponseDto()
            {
                Id = x.Id,
                Name = x.Name,
                File = x.File
            }).ToList(),
            TotalCount = entities.Count
        };
    }
}