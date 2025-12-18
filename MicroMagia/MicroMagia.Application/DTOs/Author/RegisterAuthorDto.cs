using MicroMagia.Application.DTOs.User;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Application.DTOs.Author;

public class RegisterAuthorDto
{
    public string Name { get; set; }
    public RegisterUserDto User { get; set; }


    public static implicit operator Domain.BackOffice.Entities.Author(RegisterAuthorDto model)
        => new Domain.BackOffice.Entities.Author(model.Name, new (new Email(model.User.Email),model.User.Password));
}