using UniversityACS.Core.Entities;

namespace UniversityACS.Core.DTOs.Requests;

public class NewsDto
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public bool IsFromDepartment { get; set; }
    public string? Description { get; set; }
}