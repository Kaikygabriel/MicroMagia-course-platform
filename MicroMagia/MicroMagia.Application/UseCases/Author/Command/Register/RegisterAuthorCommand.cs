using MediatR;
using MicroMagia.Application.DTOs.Author;

namespace MicroMagia.Application.UseCases.Author.Command.Register;

public record RegisterAuthorCommand(RegisterAuthorDto Author):  IRequest<string>;