using MediatR;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Author.Command.Register;

public class RegisterAuthorHandler : HandlerBaseAuthor, IRequestHandler<RegisterAuthorCommand,string?>
{
    private readonly IRegisterUserService _userService;
    public RegisterAuthorHandler(IUnitOfWork ofWork, ITokenService tokenService, IRegisterUserService userService) : base(ofWork, tokenService)
    {
        _userService = userService;
    }

    public async Task<string?> Handle(RegisterAuthorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            return await RegisterAuthorAsync(request.Author);
        }
        catch (Exception e)
        {
            return null;
        }
    }

    private async Task<string?> RegisterAuthorAsync(Domain.BackOffice.Entities.Author author)
    {
        if(await AuthorExisting(author.User.Email.Address))
            return null;
        var resultRegisterUser = await _userService.Register(author.User);
        if (!resultRegisterUser)
            return null;
        _ofWork.RepositoryAuthor.Create(author);
        await _ofWork.CommitAsync();

        return GenerateTokenOfAuthor(author);
    }

    private async Task<bool> AuthorExisting(string email)
    {
        if(_ofWork.RepositoryAuthor.GetByPredicateOrNull(x=>x.User.Email.Address == email)
           is not null)
            return true;
        return false;
    }
}