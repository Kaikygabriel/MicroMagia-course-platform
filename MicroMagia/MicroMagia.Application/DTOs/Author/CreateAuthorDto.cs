namespace MicroMagia.Application.DTOs.Author;

public class CreateAuthorDto
{
    public string Name { get; set; }
    public Domain.BackOffice.Entities.User User { get; set; }


    public static implicit operator Domain.BackOffice.Entities.Author(CreateAuthorDto model)
        => new Domain.BackOffice.Entities.Author(model.Name, model.User);
}