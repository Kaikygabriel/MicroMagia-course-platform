using MicroMagia.Application.UseCases.Career.Query.GetAll;
using MicroMagia.Test.Mocks;

namespace MicroMagia.Test.Application.UseCases.Career.Query;

public class GetAllCareerTest
{
    private readonly GetAllCareerHandler _handler= new (new FakeUnitOfWork());
    [Fact]
    public async Task Should_Return_All_Careers()
    {
        var careers = 
            await _handler.Handle(new GetAllCareerQuery(0,10));
        Assert.NotNull( careers );
    }
}