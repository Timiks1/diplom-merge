namespace UniversityACS.Core.DTOs.Responses;

public class ScientificAndPedagogicalActivityResponseDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    public string? TeacherName { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}