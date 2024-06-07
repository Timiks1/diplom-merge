using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class IndividualPlanMappings
{
    public static IndividualPlan ToEntity(this IndividualPlanDto dto)
    {
        return new IndividualPlan
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this IndividualPlan entity, IndividualPlanDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }

    public static IndividualPlanResponseDto ToDto(this IndividualPlan entity)
    {
        return new IndividualPlanResponseDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            TeacherUserName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}