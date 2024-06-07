using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class DepartmentMappings
{
    public static Department ToEntity(this DepartmentDto dto)
    {
        return new Department
        {
            Id = dto.Id,
            Name = dto.Name,
            HeadOfDepartmentId = dto.HeadOfDepartmentId,
            Description = dto.Description,
            Contacts = dto.Contacts
        };
    }

    public static void UpdateEntity(this Department department, DepartmentDto dto)
    {
        department.Name = dto.Name;
        department.HeadOfDepartmentId = dto.HeadOfDepartmentId;
        department.Description = dto.Description;
        department.Contacts = dto.Contacts;
    }

    public static DepartmentDto ToDto(this Department department)
    {
        return new DepartmentDto
        {
            Id = department.Id,
            Name = department.Name,
            HeadOfDepartmentId = department.HeadOfDepartmentId,
            Description = department.Description,
            Contacts = department.Contacts
        };
    }
}