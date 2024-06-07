using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class ExchangeVisitsPlanMappings
{
    public static ExchangeVisitsPlan ToEntity(this ExchangeVisitsPlanDto dto)
    {
        return new ExchangeVisitsPlan
        {
            Id = dto.Id,
            TeacherId = dto.TeacherId,
            Name = dto.Name
        };
    }

    public static void UpdateEntity(this ExchangeVisitsPlan entity, ExchangeVisitsPlanDto dto)
    {
        entity.TeacherId = dto.TeacherId;
        entity.Name = dto.Name;
    }
    
    public static ExchangeVisitsPlanResponseDto ToDto(this ExchangeVisitsPlan entity)
    {
        return new ExchangeVisitsPlanResponseDto
        {
            Id = entity.Id, 
            TeacherId = entity.TeacherId, 
            TeacherUserName = entity.Teacher?.UserName,
            Name = entity.Name,
            File = entity.File
        };
    }
}