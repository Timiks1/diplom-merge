using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class DepartmentMeetingProtocolMappings
{
    public static Core.Entities.DepartmentMeetingProtocol ToEntity(this DepartmentMeetingProtocolDto dto)
    {
        return new Core.Entities.DepartmentMeetingProtocol
        {
            Id = dto.Id,
            Date = dto.Date,
            DepartmentId = dto.DepartmentId,
            Name = dto.Name,
        };
    }

    public static void UpdateEntity(this Core.Entities.DepartmentMeetingProtocol entity,
        DepartmentMeetingProtocolDto dto)
    {
        entity.Date = dto.Date;
        entity.DepartmentId = dto.DepartmentId;
        entity.Name = dto.Name;
    }

    public static DepartmentMeetingProtocolResponseDto ToDto(this Core.Entities.DepartmentMeetingProtocol entity)
    {
        return new DepartmentMeetingProtocolResponseDto
        {
            Id = entity.Id,
            Date = entity.Date,
            DepartmentId = entity.DepartmentId,
            DepartmentName = entity.Department?.Name,
            Name = entity.Name,
            File = entity.File
        };
    }
}