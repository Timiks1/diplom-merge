using Microsoft.EntityFrameworkCore;
using UniversityACS.Application.Mappings;
using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Data.DataContext;

namespace UniversityACS.Application.Services.DepartmentServices;

public class DepartmentService : IDepartmentService
{
    private readonly ApplicationDbContext _context;

    public DepartmentService(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<CreateResponseDto<DepartmentDto>> CreateAsync(DepartmentDto dto, CancellationToken cancellationToken)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(x => x.Name == dto.Name, cancellationToken);

        if (existingDepartment != null)
        {
            return new CreateResponseDto<DepartmentDto>()
            {
                Success = false,
                ErrorMessage = "Department with the same name already exists."
            };
        }

        var department = dto.ToEntity();
        await _context.Departments.AddAsync(department, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return new CreateResponseDto<DepartmentDto>()
        {
            Item = department.ToDto(),
            Id = department.Id,
            Success = true
        };
    }

    public async Task<UpdateResponseDto<DepartmentDto>> UpdateAsync(Guid id, DepartmentDto dto, CancellationToken cancellationToken)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingDepartment == null)
        {
            return new UpdateResponseDto<DepartmentDto>()
            {
                Success = false,
                ErrorMessage = "Department not found."
            };
        }
        
        existingDepartment.UpdateEntity(dto);
        _context.Departments.Update(existingDepartment);
        await _context.SaveChangesAsync(cancellationToken);

        return new UpdateResponseDto<DepartmentDto>()
        {
            Item = existingDepartment.ToDto(), 
            Id = existingDepartment.Id, 
            Success = true
        };
    }

    public async Task<ResponseDto> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingDepartment == null)
        {
            return new ResponseDto()
            {
                Success = false,
                ErrorMessage = "Department not found."
            };
        }
        
        _context.Departments.Remove(existingDepartment);
        await _context.SaveChangesAsync(cancellationToken);

        return new ResponseDto() { Success = true };
    }

    public async Task<DetailsResponseDto<DepartmentDto>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        if (existingDepartment == null)
        {
            return new DetailsResponseDto<DepartmentDto>()
            {
                Success = false,
                ErrorMessage = "Department not found."
            };
        }

        return new DetailsResponseDto<DepartmentDto>()
        {
            Success = true,
            Item = existingDepartment.ToDto()
        };
    }

    public async Task<ListResponseDto<DepartmentDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var departments = await _context.Departments
            .ToListAsync(cancellationToken);

        return new ListResponseDto<DepartmentDto>()
        {
            Items = departments.Select(d => d.ToDto()).ToList(),
            TotalCount = departments.Count,
            Success = true
        };
    }
}