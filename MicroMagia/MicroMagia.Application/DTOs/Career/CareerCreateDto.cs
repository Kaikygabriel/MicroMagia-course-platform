namespace MicroMagia.Application.DTOs.Career;

public class CareerCreateDto
{
    public CareerCreateDto()
    {
        
    }

    public CareerCreateDto(string title)
    {
        Title = title;
    }
    public string Title { get; set; }

    public static implicit operator Domain.BackOffice.Entities.Career(CareerCreateDto careerDto)
        => new(careerDto.Title);
}