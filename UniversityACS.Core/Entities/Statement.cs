namespace UniversityACS.Core.Entities;

public class Statement
{
    public Guid Id { get; set; }

    public string Subject { get; set; } = string.Empty;

    public string? Name { get; set; }
    public byte[]? File { get; set; }
}