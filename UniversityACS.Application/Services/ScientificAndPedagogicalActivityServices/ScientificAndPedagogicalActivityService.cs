using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.ScientificAndPedagogicalActivityServices;

public class ScientificAndPedagogicalActivityService : IScientificAndPedagogicalActivityService
{
    private readonly ApplicationDbContext _context;

    public ScientificAndPedagogicalActivityService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<ScientificAndPedagogicalActivityDto>> CreateAsync(
        ScientificAndPedagogicalActivityDto dto, CancellationToken cancellationToken)
    {
        var activity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            activity.File = memoryStream.ToArray();
        }

        await _context.ScientificAndPedagogicalActivities.AddAsync(activity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        
        return new CreateResponseDto<ScientificAndPedagogicalActivityDto>
        {
            Success = true, Id = activity.Id
        };
    }

    public async Task<UpdateResponseDto<ScientificAndPedagogicalActivityDto>> UpdateAsync(Guid id, 
        ScientificAndPedagogicalActivityDto dto, CancellationToken cancellationToken)
    {
        var existingActivity = await _context.ScientificAndPedagogicalActivities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingActivity == null)
        {
            return new UpdateResponseDto<ScientificAndPedagogicalActivityDto>
            {
                Success = false, ErrorMessage = "Activity not found"
            };
        }
        
        existingActivity.UpdateEntity(dto);
        
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingActivity.File = memoryStream.ToArray();
        }
        
        _context.ScientificAndPedagogicalActivities.Update(existingActivity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<ScientificAndPedagogicalActivityDto>
        {
            Success = true, Id = existingActivity.Id
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingActivity = await _context.ScientificAndPedagogicalActivities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingActivity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Activity not found"
            };
        }
        
        _context.ScientificAndPedagogicalActivities.Remove(existingActivity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<ScientificAndPedagogicalActivityResponseDto>> GetByIdAsync(Guid id, 
        CancellationToken cancellationToken)
    {
        var existingActivity = await _context.ScientificAndPedagogicalActivities
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingActivity == null)
        {
            return new DetailsResponseDto<ScientificAndPedagogicalActivityResponseDto>
            {
                Success = false, ErrorMessage = "Activity not found"
            };
        }
        
        return new DetailsResponseDto<ScientificAndPedagogicalActivityResponseDto>
        {
            Success = true, 
            Item = existingActivity.ToDto(),
        };
    }

    public async Task<ListResponseDto<ScientificAndPedagogicalActivityResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var activities = await _context.ScientificAndPedagogicalActivities
            .ToListAsync(cancellationToken);
        
        return new ListResponseDto<ScientificAndPedagogicalActivityResponseDto>
        {
            Success = true, 
            Items = activities.Select(a => a.ToDto()).ToList(), 
            TotalCount = activities.Count
        };
    }

    public async Task<ListResponseDto<ScientificAndPedagogicalActivityResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var activities = await _context.ScientificAndPedagogicalActivities
            .Where(x=>x.TeacherId == userId)
            .ToListAsync(cancellationToken);
        
        return new ListResponseDto<ScientificAndPedagogicalActivityResponseDto>
        {
            Success = true, 
            Items = activities.Select(a => a.ToDto()).ToList(), 
            TotalCount = activities.Count
        };
    }
}