using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class StatementMappings
{
    public static Statement ToEntity(this StatementDto dto)
    {
        return new Statement
        {
            Id = dto.Id,
            Subject = dto.Subject,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this Statement entity, StatementDto dto)
    {
        entity.Subject = dto.Subject;
        entity.Name = dto.Name;
    }

    public static StatementResponseDto ToDto(this Statement entity)
    {
        return new StatementResponseDto
        {
            Id = entity.Id, 
            Subject = entity.Subject, 
            Name = entity.Name, 
            File = entity.File
        };
    }
}