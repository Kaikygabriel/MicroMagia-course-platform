namespace MicroMagia.Application.DTOs.Career;

public class CareerCreateDto
{
    public string Title { get; set; }

    public static implicit operator Domain.BackOffice.Entities.Career(CareerCreateDto careerDto)
        => new(careerDto.Title);
}