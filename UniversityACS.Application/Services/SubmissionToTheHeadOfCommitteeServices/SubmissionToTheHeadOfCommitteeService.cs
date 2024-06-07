using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.SubmissionToTheHeadOfCommitteeServices;

public class SubmissionToTheHeadOfCommitteeService : ISubmissionToTheHeadOfCommitteeService
{
    private readonly ApplicationDbContext _context;

    public SubmissionToTheHeadOfCommitteeService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<SubmissionToTheHeadOfCommitteeDto>> CreateAsync(SubmissionToTheHeadOfCommitteeDto dto, CancellationToken cancellationToken)
    {
        var entity = new SubmissionToTheHeadOfCommittee()
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

        await _context.SubmissionToTheHeadOfCommittees.AddAsync(entity, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<SubmissionToTheHeadOfCommitteeDto>()
        {
            Success = true,
            Id = entity.Id
        };
    }

    public async Task<UpdateResponseDto<SubmissionToTheHeadOfCommitteeDto>> UpdateAsync(Guid id, SubmissionToTheHeadOfCommitteeDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToTheHeadOfCommittees
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<SubmissionToTheHeadOfCommitteeDto>()
            {
                Success = false, ErrorMessage = "SubmissionToTheHeadOfCommittee not found"
            };
        }

        entity.Name = dto.Name;
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            entity.File = memoryStream.ToArray();
        }
        
        _context.SubmissionToTheHeadOfCommittees.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<SubmissionToTheHeadOfCommitteeDto>() { Success = true, Id = entity.Id };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToTheHeadOfCommittees
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto()
            {
                Success = false, ErrorMessage = "SubmissionToTheHeadOfCommittee not found"
            };
        }
        
        _context.SubmissionToTheHeadOfCommittees.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.SubmissionToTheHeadOfCommittees
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>()
            {
                Success = false, ErrorMessage = "SubmissionToTheHeadOfCommittee not found"
            };
        }

        return new DetailsResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>()
        {
            Success = true,
            Item = new SubmissionToTheHeadOfCommitteeResponseDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                File = entity.File
            }
        };
    }

    public async Task<ListResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.SubmissionToTheHeadOfCommittees
            .ToListAsync(cancellationToken);

        return new ListResponseDto<SubmissionToTheHeadOfCommitteeResponseDto>()
        {
            Success = true,
            Items = entities.Select(x => new SubmissionToTheHeadOfCommitteeResponseDto()
            {
                Id = x.Id,
                Name = x.Name,
                File = x.File
            }).ToList(),
            TotalCount = entities.Count
        };
    }
}