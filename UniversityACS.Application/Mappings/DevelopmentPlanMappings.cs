using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class DevelopmentPlanMappings
{
    public static DevelopmentPlan ToEntity(this DevelopmentPlanDto dto)
    {
        return new DevelopmentPlan
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this DevelopmentPlan entity, DevelopmentPlanDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }
    
    public static DevelopmentPlanResponseDto ToDto(this DevelopmentPlan entity)
    {
        return new DevelopmentPlanResponseDto
        {
            Id = entity.Id, 
            TeacherId = entity.TeacherId, 
            TeacherName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}