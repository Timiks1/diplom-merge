using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class ScientificAndPedagogicalAcivityMappings
{
    public static ScientificAndPedagogicalActivity ToEntity(this ScientificAndPedagogicalActivityDto dto)
    {
        return new ScientificAndPedagogicalActivity
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name,
        };
    }

    public static void UpdateEntity(this ScientificAndPedagogicalActivity entity,
        ScientificAndPedagogicalActivityDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }

    public static ScientificAndPedagogicalActivityResponseDto ToDto(this ScientificAndPedagogicalActivity entity)
    {
        return new ScientificAndPedagogicalActivityResponseDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            TeacherName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}