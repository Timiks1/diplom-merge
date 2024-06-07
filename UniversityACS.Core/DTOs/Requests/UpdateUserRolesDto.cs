namespace UniversityACS.Core.DTOs.Requests;

public class UpdateUserRolesDto
{
    public Guid UserId { get; set; }
    public List<string>? Roles { get; set; }
}