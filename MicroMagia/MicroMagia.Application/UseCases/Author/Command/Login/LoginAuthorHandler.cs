using MediatR;
using MicroMagia.Application.Services;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Author.Command.Login;

public class LoginAuthorHandler : HandlerBaseAuthor,IRequestHandler<LoginAuthorCommand,string?>
{
    public LoginAuthorHandler(IUnitOfWork ofWork, ITokenService tokenService) : base(ofWork, tokenService)
    {
    }

    public async Task<string?> Handle(LoginAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _ofWork.RepositoryAuthor.GetByEmailOrNull(request.Email);
        if (author is null || !ServiceCheckPassword.VerifyPassword(author.User.Password, request.Password))
            return null;
        return GenerateTokenOfAuthor(author);
    }
}