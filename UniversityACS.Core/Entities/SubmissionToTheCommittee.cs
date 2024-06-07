namespace UniversityACS.Core.Entities;

public class SubmissionToTheCommittee
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    public byte[]? File { get; set; }
}