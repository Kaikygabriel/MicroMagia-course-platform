using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Exceptions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Domain.Entity;

public class UserTest
{

    private readonly Email EmailValid = new("aa@gmail.com");

    private const string PasswordInvalid = "aa";
    
    
    [Fact]
    public void Should_Return_UserException_If_Password_Invalid()
    {
        Assert.Throws<UserException>(()
            => new User(EmailValid, PasswordInvalid));
    }
    
    private const string PasswordNull = null;
    [Fact]
    public void Should_Return_Exception_If_Password_Null()
    {
        Assert.Throws<UserException>(()
            => new User(EmailValid, PasswordNull));
    }
    
    private const string PasswordValid = "teste@";
    [Fact]
    public void Should_Return_NotNull_If_Password_Valid()
    {
        var user = new User(EmailValid, PasswordValid);
        Assert.NotNull(user);
    }
}