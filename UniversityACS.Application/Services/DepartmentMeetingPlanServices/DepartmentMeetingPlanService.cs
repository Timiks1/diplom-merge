using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.DepartmentMeetingPlanServices;

public class DepartmentMeetingPlanService : IDepartmentMeetingPlanService
{
    private readonly ApplicationDbContext _context;

    public DepartmentMeetingPlanService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<DepartmentMeetingPlanDto>> CreateAsync(DepartmentMeetingPlanDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.DepartmentMeetingPlans.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<DepartmentMeetingPlanDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<DepartmentMeetingPlanDto>> UpdateAsync(Guid id, DepartmentMeetingPlanDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.DepartmentMeetingPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<DepartmentMeetingPlanDto>()
            {
                Success = false, ErrorMessage = "Department Meeting Plan not found"
            };
        }
        
        entity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.DepartmentMeetingPlans.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<DepartmentMeetingPlanDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.DepartmentMeetingPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Department Meeting Plan not found"
            };
        }
        
        _context.DepartmentMeetingPlans.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<DepartmentMeetingPlanResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.DepartmentMeetingPlans
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<DepartmentMeetingPlanResponseDto>()
            {
                Success = false, ErrorMessage = "Department Meeting Plan not found"
            };
        }

        return new DetailsResponseDto<DepartmentMeetingPlanResponseDto>()
        {
            Success = true,
            Item = entity.ToDto()
        };
    }

    public async Task<ListResponseDto<DepartmentMeetingPlanResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.DepartmentMeetingPlans
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DepartmentMeetingPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<DepartmentMeetingPlanResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var entities = await _context.DepartmentMeetingPlans
            .Where(x=>x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DepartmentMeetingPlanResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}