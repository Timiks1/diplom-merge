using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class TeachingLoadMappings
{
    public static TeachingLoad ToEntity(this TeachingLoadDto dto)
    {
        return new TeachingLoad
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this TeachingLoad entity, TeachingLoadDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }

    public static TeachingLoadResponseDto ToDto(this TeachingLoad entity)
    {
        return new TeachingLoadResponseDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            TeacherUserName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}