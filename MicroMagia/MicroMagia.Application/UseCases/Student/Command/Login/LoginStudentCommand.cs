using MediatR;

namespace MicroMagia.Application.UseCases.Student.Command.Login;

public record LoginStudentCommand(string AddressEmail,string Password) : IRequest<string>;