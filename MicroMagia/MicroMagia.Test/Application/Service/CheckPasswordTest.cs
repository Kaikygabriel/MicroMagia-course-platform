using MicroMagia.Application.Services;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Application.Service;

public class CheckPasswordTest
{
    private const string PasswordInvalid = "afasdjkfd";
    private const string PasswordValid = "aluno.2022";
    
    private readonly User User = new User(new Email("teste@gmail.com"), 
        BCrypt.Net.BCrypt.HashPassword(PasswordValid));

    [Fact]
    public void Should_return_False_if_PasswordIsNotEquals_UserPassword()
    {
        var result = ServiceCheckPassword.VerifyPassword(User.Password, PasswordInvalid);
        Assert.False(result);
    }
    
    [Fact]
    public void Should_return_true_if_PasswordIsEquals_UserPassword()
    {
        var result = ServiceCheckPassword.VerifyPassword(User.Password, PasswordValid);
        Assert.True(result);
    }
}