namespace UniversityACS.Core.Entities;

public class DepartmentMeetingProtocol
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }

    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}