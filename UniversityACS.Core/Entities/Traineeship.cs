namespace UniversityACS.Core.Entities;

public class Traineeship
{
    public Guid Id { get; set; }

    public Guid? TraineeId { get; set; }
    public ApplicationUser? Trainee { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}