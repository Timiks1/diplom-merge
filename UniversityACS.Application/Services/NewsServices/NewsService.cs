using Microsoft.EntityFrameworkCore;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.NewsServices;

public class NewsService : INewsService
{
    private readonly ApplicationDbContext _context;

    public NewsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<CreateResponseDto<NewsDto>> CreateAsync(NewsDto dto, CancellationToken cancellationToken)
    {
        var entity = new News()
        {
            Id = dto.Id,
            Date = dto.Date,
            DepartmentId = dto.DepartmentId,
            Description = dto.Description,
            IsFromDepartment = dto.IsFromDepartment
        };
        
        _context.News.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        var responseDto = new CreateResponseDto<NewsDto>()
        {
            Success = true,
            Item = new NewsDto()
            {
                Id = entity.Id,
                Date = entity.Date,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                IsFromDepartment = entity.IsFromDepartment
            },
            Id = entity.Id
        };

        return responseDto;
    }

    public async Task<UpdateResponseDto<NewsDto>> UpdateAsync(Guid id, NewsDto dto, CancellationToken cancellationToken)
    {
        var entity = await _context.News
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new UpdateResponseDto<NewsDto>() { Success = false, ErrorMessage = "News not found" };
        }

        entity.Date = dto.Date;
        entity.Description = dto.Description;
        entity.DepartmentId = dto.DepartmentId;
        entity.IsFromDepartment = dto.IsFromDepartment;
        
        _context.News.Update(entity);
        await _context.SaveChangesAsync(cancellationToken);

        var responseDto = new UpdateResponseDto<NewsDto>()
        {
            Success = true,
            Item = new NewsDto()
            {
                Id = entity.Id,
                Date = entity.Date,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                IsFromDepartment = entity.IsFromDepartment
            },
            Id = entity.Id
        };

        return responseDto;
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.News
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new ResponseDto() { Success = false, ErrorMessage = "News not found" };
        }
        
        _context.News.Remove(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<NewsDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var entity = await _context.News
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (entity == null)
        {
            return new DetailsResponseDto<NewsDto>() { Success = false, ErrorMessage = "News not found" };
        }

        return new DetailsResponseDto<NewsDto>()
        {
            Success = true,
            Item = new NewsDto()
            {
                Id = entity.Id,
                Date = entity.Date,
                Description = entity.Description,
                DepartmentId = entity.DepartmentId,
                IsFromDepartment = entity.IsFromDepartment
            }
        };
    }

    public async Task<ListResponseDto<NewsDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.News
            .ToListAsync(cancellationToken);

        return new ListResponseDto<NewsDto>()
        {
            Success = true,
            Items = entities.Select(entity => new NewsDto()
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    Description = entity.Description,
                    DepartmentId = entity.DepartmentId,
                    IsFromDepartment = entity.IsFromDepartment
                })
                .ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<NewsDto>> GetByDepartmentIdAsync(Guid departmentId, CancellationToken cancellationToken)
    {
        var entities = await _context.News
            .Where(x=>x.DepartmentId == departmentId)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<NewsDto>()
        {
            Success = true,
            Items = entities.Select(entity => new NewsDto()
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    Description = entity.Description,
                    DepartmentId = entity.DepartmentId,
                    IsFromDepartment = entity.IsFromDepartment
                })
                .ToList(),
            TotalCount = entities.Count
        };
    }

    public async Task<ListResponseDto<NewsDto>> GetStudyPartNewsAsync(CancellationToken cancellationToken)
    {
        var entities = await _context.News
            .Where(x=>!x.IsFromDepartment)
            .ToListAsync(cancellationToken);

        return new ListResponseDto<NewsDto>()
        {
            Success = true,
            Items = entities.Select(entity => new NewsDto()
                {
                    Id = entity.Id,
                    Date = entity.Date,
                    Description = entity.Description,
                    DepartmentId = entity.DepartmentId,
                    IsFromDepartment = entity.IsFromDepartment
                })
                .ToList(),
            TotalCount = entities.Count
        };
    }
}