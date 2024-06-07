using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.TraineeshipServices;

public class TraineeshipService : ITraineeshipService
{
    private readonly ApplicationDbContext _context;

    public TraineeshipService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<TraineeshipDto>> CreateAsync(TraineeshipDto dto, CancellationToken cancellationToken)
    {
        var traineeship = dto.ToEntity();
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            traineeship.File = memoryStream.ToArray();
        }
        
        await _context.Traineeships.AddAsync(traineeship, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<TraineeshipDto>()
        {
            Id = traineeship.Id,
            Success = true
        };
    }

    public async Task<UpdateResponseDto<TraineeshipDto>> UpdateAsync(Guid id, TraineeshipDto dto, CancellationToken cancellationToken)
    {
        var existingTraineeship = await _context.Traineeships
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingTraineeship == null)
        {
            return new UpdateResponseDto<TraineeshipDto>()
            {
                Success = false, 
                ErrorMessage = "Traineeship not found"
            };
        }
        
        existingTraineeship.UpdateEntity(dto);
        if (dto.File != null)
        {
            using var memoryStream = new MemoryStream();
            await dto.File.CopyToAsync(memoryStream, cancellationToken);
            existingTraineeship.File = memoryStream.ToArray();
        }
        
        _context.Traineeships.Update(existingTraineeship);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<TraineeshipDto>()
        {
            Id = existingTraineeship.Id, 
            Success = true
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingTraineeship = await _context.Traineeships
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingTraineeship == null)
        {
            return new ResponseDto()
            {
                Success = false, 
                ErrorMessage = "Traineeship not found"
            };
        }
        
        _context.Traineeships.Remove(existingTraineeship);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<TraineeshipResponseDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingTraineeship = await _context.Traineeships
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingTraineeship == null)
        {
            return new DetailsResponseDto<TraineeshipResponseDto>()
            {
                Success = false, ErrorMessage = "Traineeship not found"
            };
        }
        
        return new DetailsResponseDto<TraineeshipResponseDto>()
        {
            Item = existingTraineeship.ToDto(), 
            Success = true
        };
    }

    public async Task<ListResponseDto<TraineeshipResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var traineeships = await _context.Traineeships
            .ToListAsync(cancellationToken);

        return new ListResponseDto<TraineeshipResponseDto>()
        {
            Items = traineeships.Select(t => t.ToDto()).ToList(),
            TotalCount = traineeships.Count,
            Success = true
        };
    }

    public async Task<ListResponseDto<TraineeshipResponseDto>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        var traineeships = await _context.Traineeships
            .Where(x=>x.TraineeId == userId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<TraineeshipResponseDto>()
        {
            Items = traineeships.Select(t => t.ToDto()).ToList(),
            TotalCount = traineeships.Count,
            Success = true
        };
    }
}