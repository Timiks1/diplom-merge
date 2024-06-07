using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.IndividualPlanServices;

public class IndividualPlanService : IIndividualPlanService
{
    private readonly ApplicationDbContext _context;

    public IndividualPlanService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<IndividualPlanDto>> CreateAsync(IndividualPlanDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.IndividualPlans.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<IndividualPlanDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<IndividualPlanDto>> UpdateAsync(Guid id, IndividualPlanDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.IndividualPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<IndividualPlanDto>()
            {
                Success = false,
                ErrorMessage = "IndividualPlan not found"
            };
        }
        
        existingEntity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }
        
        _context.IndividualPlans.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<IndividualPlanDto>() { Success = true, Id = existingEntity.Id};
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.IndividualPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "IndividualPlan not found"
            };
        }
        
        _context.IndividualPlans.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<IndividualPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.IndividualPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<IndividualPlanResponseDto>()
            {
                Success = false,
                ErrorMessage = "IndividualPlan not found"
            };
        }

        return new DetailsResponseDto<IndividualPlanResponseDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<IndividualPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.IndividualPlans
            .ToListAsync(cancellationToken);

        return new ListResponseDto<IndividualPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<IndividualPlanResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.IndividualPlans
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<IndividualPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}