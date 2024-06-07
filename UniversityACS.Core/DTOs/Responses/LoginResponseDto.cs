namespace UniversityACS.Core.DTOs.Responses;

public class LoginResponseDto
{
    public bool Success { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Expiration { get; set; } = string.Empty;
}