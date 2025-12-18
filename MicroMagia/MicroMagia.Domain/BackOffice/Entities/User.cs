using MicroMagia.Domain.BackOffice.Entities.Abstractions;
using MicroMagia.Domain.BackOffice.Exceptions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Domain.BackOffice.Entities;

public class User : Entity
{
    protected User()
    {
        
    }
    public User(Email email, string password)
    {
        if (IsValidPassword(password))
            throw new UserException("Password is invalid");
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
    }

    public Email Email { get;private set; }
    public string Password { get;private set; }

    private bool IsValidPassword(string password)
        => string.IsNullOrEmpty(password) || password.Length < 3;

    public void UpdatePassword(string pass)
        => Password = pass;
}