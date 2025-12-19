using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.Services;

public class RegisterUserService : IRegisterUserService
{
    private readonly IUnitOfWork _ofWork; 
    public RegisterUserService(IUnitOfWork ofWork)
    {
        _ofWork = ofWork;
    }
    public async Task<bool> Register(Domain.BackOffice.Entities.User request)
    {
        try
        {
            return await RegisterUser( request);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    private async Task<bool> RegisterUser(Domain.BackOffice.Entities.User request)
    { 
        if (await _ofWork.RepositoryUser.GetByPredicateOrNull(x => x.Email.Address == request.Email.Address) is null)
        {
            AddHashPasswordInUser(request);
            _ofWork.RepositoryUser.Create(request);
        
            return true;
        }
        return false;
    }

    private void AddHashPasswordInUser(Domain.BackOffice.Entities.User user)
    {
        var password = user.Password;
        user.UpdatePassword(BCrypt.Net.BCrypt.HashPassword(password));
    }
}