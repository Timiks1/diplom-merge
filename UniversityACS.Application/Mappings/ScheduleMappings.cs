using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class ScheduleMappings
{
    public static Schedule ToEntity(this ScheduleDto dto)
    {
        return new Schedule
        {
            Id = dto.Id,
            DepartmentId = dto.DepartmentId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this Schedule entity, ScheduleDto dto)
    {
        entity.DepartmentId = dto.DepartmentId;
        entity.Name = dto.Name;
    }

    public static ScheduleResponseDto ToDto(this Schedule entity)
    {
        return new ScheduleResponseDto
        {
            Id = entity.Id,
            DepartmentId = entity.DepartmentId,
            DepartmentName = entity.Department?.Name,
            Name = entity.Name,
            File = entity.File
        };
    }
}