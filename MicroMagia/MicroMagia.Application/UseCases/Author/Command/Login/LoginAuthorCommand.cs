using MediatR;

namespace MicroMagia.Application.UseCases.Author.Command.Login;

public record LoginAuthorCommand(string Email,string Password)  :IRequest<string?>;