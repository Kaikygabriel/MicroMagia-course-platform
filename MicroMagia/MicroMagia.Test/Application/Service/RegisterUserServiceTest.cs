using MicroMagia.Application.Services;
using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.ObjectValue;
using MicroMagia.Test.Mocks;

namespace MicroMagia.Test.Application.Service;

public class RegisterUserServiceTest
{
    private readonly RegisterUserService _service = new(new FakeUnitOfWork());

    private readonly User UserExisting = new User(new Email("admin@micromagia.com"), "admin123");
    
    [Fact]
    public async Task Should_Return_False_If_User_Existing()
    {
        var result = await _service.Register(UserExisting);
        Assert.False(result);
    }
    private readonly User UserValid = new User(new Email("tste@teste.com"), "teste");

    [Fact]
    public async Task Should_Return_True_If_User_NoExisting()
    {
        var result = await _service.Register(UserValid);
        Assert.True(result);
    }
    
    [Fact]
    public async Task Should_Return_a_NewPassword_When_UserBeRegister()
    {
        var result = await _service.Register(UserValid);
        bool PasswordIsHash = UserValid.Password.Length > 5; 
        Assert.True(PasswordIsHash);
    }
}