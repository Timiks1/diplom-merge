using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.CurriculumServices;

public class CurriculumService : ICurriculumService
{
    private readonly ApplicationDbContext _context;

    public CurriculumService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<CurriculumDto>> CreateAsync(CurriculumDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.Curricula.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<CurriculumDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<CurriculumDto>> UpdateAsync(Guid id, CurriculumDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.Curricula
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<CurriculumDto>()
            {
                Success = false,
                ErrorMessage = "Curriculum not found"
            };
        }
        
        existingEntity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }
        
        _context.Curricula.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<CurriculumDto>() { Success = true, Id = existingEntity.Id};
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.Curricula
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "Curriculum not found"
            };
        }
        
        _context.Curricula.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<CurriculumResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.Curricula
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<CurriculumResponseDto>()
            {
                Success = false,
                ErrorMessage = "Curriculum not found"
            };
        }

        return new DetailsResponseDto<CurriculumResponseDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<CurriculumResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.Curricula
            .ToListAsync(cancellationToken);

        return new ListResponseDto<CurriculumResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<CurriculumResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.Curricula
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<CurriculumResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}