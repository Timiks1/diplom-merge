namespace UniversityACS.Core.DTOs;

public class DetailsResponseDto<T> : ResponseDto where T : class
{
    public T? Item { get; set; }
}