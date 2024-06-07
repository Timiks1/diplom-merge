namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class TeacherDisciplines
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(TeacherDisciplines)}";
        
        public const string UpsertDisciplinesToTeacher = $"{Base}/{nameof(UpsertDisciplinesToTeacher)}";
        public const string DeleteDisciplinesFromTeacher = $"{Base}/{nameof(DeleteDisciplinesFromTeacher)}";
    }
}