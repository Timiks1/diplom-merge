using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.DepartmentMeetingProtocolServices;

public class DepartmentMeetingProtocolService : IDepartmentMeetingProtocolService
{
    private readonly ApplicationDbContext _context;

    public DepartmentMeetingProtocolService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<DepartmentMeetingProtocolDto>> CreateAsync(DepartmentMeetingProtocolDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.DepartmentMeetingProtocols.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<DepartmentMeetingProtocolDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<DepartmentMeetingProtocolDto>> UpdateAsync(Guid id, DepartmentMeetingProtocolDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.DepartmentMeetingProtocols
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<DepartmentMeetingProtocolDto>()
            {
                Success = false, ErrorMessage = "Department Meeting Protocol not found"
            };
        }
        
        entity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.DepartmentMeetingProtocols.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<DepartmentMeetingProtocolDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.DepartmentMeetingProtocols
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Department Meeting Protocol not found"
            };
        }
        
        _context.DepartmentMeetingProtocols.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<DepartmentMeetingProtocolResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.DepartmentMeetingProtocols
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<DepartmentMeetingProtocolResponseDto>()
            {
                Success = false, ErrorMessage = "Department Meeting Protocol not found"
            };
        }

        return new DetailsResponseDto<DepartmentMeetingProtocolResponseDto>()
        {
            Success = true,
            Item = entity.ToDto()
        };
    }

    public async Task<ListResponseDto<DepartmentMeetingProtocolResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.DepartmentMeetingProtocols
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DepartmentMeetingProtocolResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<DepartmentMeetingProtocolResponseDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var entities = await _context.DepartmentMeetingProtocols
            .Where(x=>x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DepartmentMeetingProtocolResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}