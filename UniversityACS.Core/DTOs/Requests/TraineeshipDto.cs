using Microsoft.AspNetCore.Http;

namespace UniversityACS.Core.DTOs.Requests;

public class TraineeshipDto
{
    public Guid Id { get; set; }

    public Guid? TraineeId { get; set; }
    public string? Name { get; set; }
    public IFormFile? File { get; set; }
}