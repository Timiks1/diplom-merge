using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class WorkingCurriculumMappings
{
    public static WorkingCurriculum ToEntity(this WorkingCurriculumDto dto)
    {
        return new WorkingCurriculum
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this WorkingCurriculum entity, WorkingCurriculumDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }

    public static WorkingCurriculumResponseDto ToDto(this WorkingCurriculum entity)
    {
        return new WorkingCurriculumResponseDto
        {
            Id = entity.Id,
            TeacherId = entity.TeacherId,
            TeacherUserName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}