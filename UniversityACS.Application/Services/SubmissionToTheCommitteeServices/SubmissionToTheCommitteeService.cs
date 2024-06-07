using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.SubmissionToTheCommitteeServices;

public class SubmissionToTheCommitteeService : ISubmissionToTheCommitteeService
{
    private readonly ApplicationDbContext _context;

    public SubmissionToTheCommitteeService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<SubmissionToTheCommitteeDto>> CreateAsync(SubmissionToTheCommitteeDto dto, CancellationToken cancellationToken)
    {
        var entity = new SubmissionToTheCommittee()
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

        await _context.SubmissionToTheCommittees.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<SubmissionToTheCommitteeDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<SubmissionToTheCommitteeDto>> UpdateAsync(Guid id, SubmissionToTheCommitteeDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToTheCommittees
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<SubmissionToTheCommitteeDto>()
            {
                Success = false, ErrorMessage = "SubmissionToTheCommittee not found"
            };
        }

        entity.Name = dto.Name;
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.SubmissionToTheCommittees.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<SubmissionToTheCommitteeDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToTheCommittees
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "SubmissionToTheCommittee not found"
            };
        }
        
        _context.SubmissionToTheCommittees.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<SubmissionToTheCommitteeResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToTheCommittees
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<SubmissionToTheCommitteeResponseDto>()
            {
                Success = false, ErrorMessage = "SubmissionToTheCommittee not found"
            };
        }

        return new DetailsResponseDto<SubmissionToTheCommitteeResponseDto>()
        {
            Success = true,
            Item = new SubmissionToTheCommitteeResponseDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                File = entity.File
            }
        };
    }

    public async Task<ListResponseDto<SubmissionToTheCommitteeResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.SubmissionToTheCommittees
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SubmissionToTheCommitteeResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => new SubmissionToTheCommitteeResponseDto()
            {
                Id = x.Id,
                Name = x.Name,
                File = x.File
            }).ToList(),
            TotalCount = entities.Count
        };
    }
}