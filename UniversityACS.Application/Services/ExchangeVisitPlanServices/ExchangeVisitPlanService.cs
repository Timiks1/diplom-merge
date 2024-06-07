using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ExchangeVisitPlanServices;

public class ExchangeVisitPlanService : IExchangeVisitPlanService
{
    private readonly ApplicationDbContext _context;

    public ExchangeVisitPlanService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<ExchangeVisitsPlanDto>> CreateAsync(ExchangeVisitsPlanDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.ExchangeVisitsPlans.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<ExchangeVisitsPlanDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<ExchangeVisitsPlanDto>> UpdateAsync(Guid id, ExchangeVisitsPlanDto dto, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.ExchangeVisitsPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new UpdateResponseDto<ExchangeVisitsPlanDto>()
            {
                Success = false,
                ErrorMessage = "ExchangeVisitsPlan not found"
            };
        }
        
        existingEntity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingEntity.File = memoryStream.ToArray();
        }
        
        _context.ExchangeVisitsPlans.Update(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ExchangeVisitsPlanDto>() { Success = true, Id = existingEntity.Id};
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.ExchangeVisitsPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "ExchangeVisitsPlan not found"
            };
        }
        
        _context.ExchangeVisitsPlans.Remove(existingEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ExchangeVisitsPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingEntity = await _context.ExchangeVisitsPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingEntity == null)
        {
            return new DetailsResponseDto<ExchangeVisitsPlanResponseDto>()
            {
                Success = false,
                ErrorMessage = "ExchangeVisitsPlan not found"
            };
        }

        return new DetailsResponseDto<ExchangeVisitsPlanResponseDto>()
        {
            Item = existingEntity.ToDto(),
            Success = true
        };
    }

    public async Task<ListResponseDto<ExchangeVisitsPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.ExchangeVisitsPlans
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ExchangeVisitsPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<ExchangeVisitsPlanResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var entities = await _context.ExchangeVisitsPlans
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<ExchangeVisitsPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}