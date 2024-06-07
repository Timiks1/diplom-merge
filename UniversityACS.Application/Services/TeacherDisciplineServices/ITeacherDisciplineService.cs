﻿using UniversityACS.Core.DTOs;
using UniversityACS.Core.DTOs.Requests;

namespace UniversityACS.Application.Services.TeacherDisciplineServices;

public interface ITeacherDisciplineService
{
    Task<ResponseDto> UpsertDisciplinesToTeacherAsync(TeacherDisciplinesDto dto,
        CancellationToken cancellationToken = default!);

    Task<TeacherDisciplinesDto> GetTeacherDisciplinesDto(Guid id);

    Task<ResponseDto> DeleteDisciplinesFromTeacherAsync(TeacherDisciplinesDto dto,
        CancellationToken cancellationToken = default!);
}