namespace UniversityACS.Core.DTOs.Responses;

public class TraineeshipResponseDto
{
    public Guid Id { get; set; }

    public Guid? TraineeId { get; set; }
    public string? TraineeName { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}