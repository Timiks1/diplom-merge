namespace UniversityACS.Core.DTOs.Requests;

public class UpdateResponseDto<T> : ResponseDto where T : class
{
    public T? Item { get; set; }
    public Guid? Id { get; set; }
}