namespace UniversityACS.Core.DTOs.Requests;

public class TeacherDisciplinesDto
{
    public Guid TeacherId { get; set; }
    public List<Guid> DisciplineIds { get; set; } = default!;
}