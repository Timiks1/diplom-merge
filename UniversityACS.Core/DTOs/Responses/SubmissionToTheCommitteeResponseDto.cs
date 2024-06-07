namespace UniversityACS.Core.DTOs.Responses;

public class SubmissionToTheCommitteeResponseDto
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}