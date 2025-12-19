using MicroMagia.Application.DTOs.Career;
using MicroMagia.Application.UseCases.Career.Command.Create;
using MicroMagia.Test.Mocks;

namespace MicroMagia.Test.Application.UseCases.Career.Command;

public class CreateCareerTest
{
    private readonly CreateCareerHandler _handler = new CreateCareerHandler(new FakeUnitOfWork());
    [Fact]
    public async Task Should_Return_false_If_CareerExisting()
    {
        var command = new CreateCareerCommand(new CareerCreateDto("Backend Developer"));
        var result = await _handler.Handle(command,default);
        Assert.False(result);
    }
    
    [Fact]
    public async Task Should_Return_true_If_CareerNoExisting()
    {
        var command = new CreateCareerCommand(new CareerCreateDto("Cloud"));
        var result = await _handler.Handle(command,default);
        Assert.True(result);
    }
}