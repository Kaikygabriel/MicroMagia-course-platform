using MediatR;
using MicroMagia.Application.DTOs.User;

namespace MicroMagia.Application.UseCases.Student.Command.Register;

public record RegisterStudentCommand(string name,RegisterUserDto UserDto) : IRequest<string>;