namespace UniversityACS.Core.DTOs.Requests;

public class ListResponseDto<T> : ResponseDto
{
    public ICollection<T>? Items { get; set; }
    public int TotalCount { get; set; }
}