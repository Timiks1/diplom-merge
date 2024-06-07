using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.StatementServices;

public class StatementService : IStatementService
{
    private readonly ApplicationDbContext _context;

    public StatementService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<StatementDto>> CreateAsync(StatementDto dto, CancellationToken cancellationToken)
    {
        var entity = dto.ToEntity();

        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }

        await _context.Statements.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<StatementDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<StatementDto>> UpdateAsync(Guid id, StatementDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.Statements
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<StatementDto>()
            {
                Success = false, ErrorMessage = "Statement not found"
            };
        }
        
        entity.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.Statements.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<StatementDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Statements
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "Statement not found"
            };
        }
        
        _context.Statements.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<StatementResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.Statements
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<StatementResponseDto>()
            {
                Success = false, ErrorMessage = "Statement not found"
            };
        }

        return new DetailsResponseDto<StatementResponseDto>()
        {
            Success = true,
            Item = entity.ToDto()
        };
    }

    public async Task<ListResponseDto<StatementResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.Statements
            .ToListAsync(cancellationToken);

        return new ListResponseDto<StatementResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<StatementResponseDto>> GetBySubjectAsync(string subject, CancellationToken cancellationToken)
    {
        var entities = await _context.Statements
            .Where(x=>x.Subject.Equals(subject, StringComparison.CurrentCultureIgnoreCase))
            .ToListAsync(cancellationToken);

        return new ListResponseDto<StatementResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => x.ToDto()).ToList(),
            TotalCount = entities.Count
        };
    }
}