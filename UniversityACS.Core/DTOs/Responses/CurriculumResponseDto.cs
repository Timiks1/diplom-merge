namespace UniversityACS.Core.DTOs.Responses;

public class CurriculumResponseDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public string? TeacherUserName { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}