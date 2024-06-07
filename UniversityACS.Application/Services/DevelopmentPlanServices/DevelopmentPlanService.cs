using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.DevelopmentPlanServices;

public class DevelopmentPlanService : IDevelopmentPlanService
{
    private readonly ApplicationDbContext _context;

    public DevelopmentPlanService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<DevelopmentPlanDto>> CreateAsync(DevelopmentPlanDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.DevelopmentPlans.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<DevelopmentPlanDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<DevelopmentPlanDto>> UpdateAsync(Guid id, DevelopmentPlanDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.DevelopmentPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<DevelopmentPlanDto>()
            {
                Success = false,
                ErrorMessage = "DevelopmentPlan not found"
            };
        }
        
        existingEntity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }
        
        _context.DevelopmentPlans.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<DevelopmentPlanDto>() { Success = true, Id = existingEntity.Id};
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.DevelopmentPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "DevelopmentPlan not found"
            };
        }
        
        _context.DevelopmentPlans.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<DevelopmentPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.DevelopmentPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<DevelopmentPlanResponseDto>()
            {
                Success = false,
                ErrorMessage = "DevelopmentPlan not found"
            };
        }

        return new DetailsResponseDto<DevelopmentPlanResponseDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<DevelopmentPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.DevelopmentPlans
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DevelopmentPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<DevelopmentPlanResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.DevelopmentPlans
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DevelopmentPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}