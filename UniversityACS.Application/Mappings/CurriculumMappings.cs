using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class CurriculumMappings
{
    public static Curriculum ToEntity(this CurriculumDto dto)
    {
        return new Curriculum
        {
            Id = dto.Id, 
            TeacherId = dto.TeacherId, 
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this Curriculum entity, CurriculumDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }

    public static CurriculumResponseDto ToDto(this Curriculum entity)
    {
        return new CurriculumResponseDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            TeacherUserName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}