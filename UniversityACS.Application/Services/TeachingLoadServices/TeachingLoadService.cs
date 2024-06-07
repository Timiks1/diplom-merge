using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.TeachingLoadServices;

public class TeachingLoadService : ITeachingLoadService
{
    private readonly ApplicationDbContext _context;

    public TeachingLoadService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<TeachingLoadDto>> CreateAsync(TeachingLoadDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.TeachingLoads.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<TeachingLoadDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<TeachingLoadDto>> UpdateAsync(Guid id, TeachingLoadDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.TeachingLoads
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<TeachingLoadDto>()
            {
                Success = false,
                ErrorMessage = "TeachingLoad not found"
            };
        }
        
        existingEntity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }
        
        _context.TeachingLoads.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<TeachingLoadDto>() { Success = true, Id = existingEntity.Id};
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.TeachingLoads
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "TeachingLoad not found"
            };
        }
        
        _context.TeachingLoads.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<TeachingLoadResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.TeachingLoads
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<TeachingLoadResponseDto>()
            {
                Success = false,
                ErrorMessage = "TeachingLoad not found"
            };
        }

        return new DetailsResponseDto<TeachingLoadResponseDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<TeachingLoadResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.TeachingLoads
            .ToListAsync(cancellationToken);

        return new ListResponseDto<TeachingLoadResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<TeachingLoadResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.TeachingLoads
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<TeachingLoadResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}