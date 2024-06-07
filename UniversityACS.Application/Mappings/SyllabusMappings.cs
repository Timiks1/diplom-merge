using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class SyllabusMappings
{
    public static Syllabus ToEntity(this SyllabusDto dto)
    {
        return new Syllabus
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this Syllabus syllabus, SyllabusDto dto)
    {
        syllabus.TeacherId = dto.TeacherId;
        syllabus.Name = dto.Name;
    }

    public static SyllabusResponseDto ToDto(this Syllabus syllabus)
    {
        return new SyllabusResponseDto
        {
            Id = syllabus.Id,
            TeacherId = syllabus.TeacherId,
            TeacherName = syllabus.Teacher?.UserName,
            Name = syllabus.Name,
            File = syllabus.File
        };
    }
}