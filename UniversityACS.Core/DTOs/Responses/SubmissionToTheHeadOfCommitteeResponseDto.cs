namespace UniversityACS.Core.DTOs.Responses;

public class SubmissionToTheHeadOfCommitteeResponseDto
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}