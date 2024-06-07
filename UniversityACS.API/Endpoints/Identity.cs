namespace UniversityACS.API.Endpoints;

public static partial class ApiEndpoints
{
    public static class Identity
    {
        public const string Base = $"{BaseApiEndpoint}/{nameof(Identity)}";

        public const string Login = $"{Base}/{nameof(Login)}";
        public const string GetCurrentUser = $"{Base}/{nameof(GetCurrentUser)}";
    }
}