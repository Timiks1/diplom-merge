namespace UniversityACS.Core.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? HeadOfDepartmentId { get; set; }
    public ApplicationUser? HeadOfDepartment { get; set; }
    public string? Description { get; set; }
    public string? Contacts { get; set; }

    public List<ApplicationUser>? Members { get; set; }
}