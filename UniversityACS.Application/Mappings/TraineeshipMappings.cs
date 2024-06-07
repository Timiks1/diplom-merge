using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.DTOs.Responses;
using UniversityACS.Core.Entities;

namespace UniversityACS.Application.Mappings;

public static class TraineeshipMappings
{
    public static Traineeship ToEntity(this TraineeshipDto dto)
    {
        return new Traineeship
        {
            Id = dto.Id,
            TraineeId = dto.TraineeId,
            Name = dto.Name,
        };
    }

    public static void UpdateEntity(this Traineeship traineeship, TraineeshipDto dto)
    {
        traineeship.TraineeId = dto.TraineeId;
        traineeship.Name = dto.Name;
    }

    public static TraineeshipResponseDto ToDto(this Traineeship traineeship)
    {
        return new TraineeshipResponseDto
        {
            Id = traineeship.Id,
            TraineeId = traineeship.TraineeId,
            TraineeName = traineeship.Trainee?.UserName,
            Name = traineeship.Name,
            File = traineeship.File
        };
    }
}