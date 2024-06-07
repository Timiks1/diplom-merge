namespace UniversityACS.Core.DTOs.Responses;

public class WorkingCurriculumResponseDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public string? TeacherUserName { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}