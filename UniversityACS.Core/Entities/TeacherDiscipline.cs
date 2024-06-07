namespace UniversityACS.Core.Entities;

public class TeacherDiscipline
{
    public Guid TeacherId { get; set; }
    public ApplicationUser? Teacher { get; set; }
    public Guid DisciplineId { get; set; }
    public Discipline? Discipline { get; set; }
}