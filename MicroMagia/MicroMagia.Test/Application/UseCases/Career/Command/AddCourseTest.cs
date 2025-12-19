using MicroMagia.Application.UseCases.Career.Command.AddCourse;
using MicroMagia.Test.Mocks;

namespace MicroMagia.Test.Application.UseCases.Career.Command;

public class AddCourseTest
{
    private readonly AddCourseHandler _handler = new(new FakeUnitOfWork());
    
    [Fact]
    public async Task Should_Return_False_if_CareerIsNull()
    {
        var command = new AddCourseCommand(Guid.Parse("a9c4e1b7-2d6f-4f8a-b3c2-7e5d91a6f204"),Guid.NewGuid());
        var result = await _handler.Handle(command,default);
        Assert.False(result);
    }
    
    [Fact]
    public async Task Should_Return_False_if_CourseIsNull()
    {
        var command = new AddCourseCommand(Guid.NewGuid(), Guid.Parse("3f7a9c2e-8b4d-4f6a-9c21-1e7d5b8a4c93"));
        var result = await _handler.Handle(command,default);
        Assert.False(result);
    }
    
    [Fact]
    public async Task Should_Return_true_if_CareerAndCourse_Ok()
    {
        var command = new AddCourseCommand(Guid.Parse("a9c4e1b7-2d6f-4f8a-b3c2-7e5d91a6f204"),
            Guid.Parse("3f7a9c2e-8b4d-4f6a-9c21-1e7d5b8a4c93"));
        var result = await _handler.Handle(command,default);
        Assert.True(result);

    }
}