namespace UniversityACS.Core.DTOs.Responses;

public class StatementResponseDto
{
    public Guid Id { get; set; }

    public string? Subject { get; set; }

    public string? Name { get; set; }
    public byte[]? File { get; set; }
}