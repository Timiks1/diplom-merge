namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class News
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(News)}";
        
        public const string Create = Base;
        public const string Delete = $"{Base}/{{id:guid}}";
        public const string Update = $"{Base}/{{id:guid}}";
        public const string GetById = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
        public const string GetByDepartmentId = $"{Base}/{nameof(GetByDepartmentId)}/{{departmentId:guid}}";
        public const string GetStudyPartNews = $"{Base}/{nameof(GetStudyPartNews)}";
    }
}