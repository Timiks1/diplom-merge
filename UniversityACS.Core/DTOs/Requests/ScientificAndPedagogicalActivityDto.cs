using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class ScientificAndPedagogicalActivityDto
{
    public Guid Id { get; set; }

    public Guid? TeacherId { get; set; }
    
    public string? Name { get; set; }
    public IFormFile? File { get; set; }
}