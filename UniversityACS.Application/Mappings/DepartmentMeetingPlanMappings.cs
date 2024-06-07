using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class DepartmentMeetingPlanMappings
{
    public static DepartmentMeetingPlan ToEntity(this DepartmentMeetingPlanDto dto)
    {
        return new DepartmentMeetingPlan
        {
            Id = dto.Id, 
            DepartmentId = dto.DepartmentId, 
            Name = dto.Name, 
        };
    }

    public static void UpdateEntity(this DepartmentMeetingPlan entity, DepartmentMeetingPlanDto dto)
    {
        entity.DepartmentId = dto.DepartmentId;
        entity.Name = dto.Name;
    }
    
    public static DepartmentMeetingPlanResponseDto ToDto(this DepartmentMeetingPlan entity)
    {
        return new DepartmentMeetingPlanResponseDto
        {
            Id = entity.Id, 
            DepartmentId = entity.DepartmentId, 
            DepartmentName = entity.Department?.Name,
            Name = entity.Name,
            File = entity.File
        };
    }
}