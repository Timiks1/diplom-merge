namespace UniversityACS.Core.Entities;

public class News
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public Guid? DepartmentId { get; set; }
    public Department? Department { get; set; }
    public bool IsFromDepartment { get; set; }
    public string? Description { get; set; }
}