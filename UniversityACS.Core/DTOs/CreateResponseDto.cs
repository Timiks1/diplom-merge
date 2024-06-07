namespace UniversityACS.Core.DTOs;

public class CreateResponseDto<T> : ResponseDto where T : class
{
    public T? Item { get; set; }    
    public Guid? Id { get; set; }
}