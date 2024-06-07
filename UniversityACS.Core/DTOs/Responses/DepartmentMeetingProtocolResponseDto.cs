namespace UniversityACS.Core.DTOs.Responses;

public class DepartmentMeetingProtocolResponseDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public Guid? DepartmentId { get; set; }
    public string? DepartmentName { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}