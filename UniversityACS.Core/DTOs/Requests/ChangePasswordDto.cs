namespace UniversityACS.Core.DTOs.Requests;

public class ChangePasswordDto
{
    public Guid UserId { get; set; }
    public string OldPass { get; set; } = string.Empty;
    public string NewPass { get; set; } = string.Empty;
}