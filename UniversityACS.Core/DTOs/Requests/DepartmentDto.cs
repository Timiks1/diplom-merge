namespace UniversityACS.Core.DTOs.Requests;

public class DepartmentDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public Guid? HeadOfDepartmentId { get; set; }
    public string? Description { get; set; }
    public string? Contacts { get; set; }
}