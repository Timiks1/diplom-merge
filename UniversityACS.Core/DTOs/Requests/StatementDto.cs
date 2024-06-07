using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class StatementDto
{
    public Guid Id { get; set; }

    public string? Subject { get; set; }

    public string? Name { get; set; }
    public IFormFile? File { get; set; }
}