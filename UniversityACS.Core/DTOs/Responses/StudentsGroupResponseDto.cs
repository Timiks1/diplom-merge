﻿using UniversityACS.Core.DTOs.Requests;
using UniversityACS.Core.Entities;

namespace UniversityACS.Core.DTOs.Responses;

public class StudentsGroupResponseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<ApplicationUserResponseDto>? Students { get; set; }
    public List<DisciplineDto>? Disciplines { get; set; }

}