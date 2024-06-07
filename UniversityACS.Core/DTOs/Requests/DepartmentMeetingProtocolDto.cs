using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class DepartmentMeetingProtocolDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public Guid? DepartmentId { get; set; }
    
    public string? Name { get; set; }
    public IFormFile? File { get; set; }
}