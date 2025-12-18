using MediatR;
using MicroMagia.Application.DTOs.Author;

namespace MicroMagia.Application.UseCases.Author.Command.Register;

public record RegisterAuthorCommand(CreateAuthorDto Author):  IRequest<string>;