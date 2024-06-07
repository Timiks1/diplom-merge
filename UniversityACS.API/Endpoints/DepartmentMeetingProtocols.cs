namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class DepartmentMeetingProtocols
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(DepartmentMeetingProtocols)}";
        
        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetByDepartmentId = $"{Base}/{nameof(GetByDepartmentId)}/{{departmentId:guid}}";
        public const string GetAll = Base;
    }
}