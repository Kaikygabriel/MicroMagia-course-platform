using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Domain.Entity;

public class CourseTest
{
    [Fact]
    public void Should_Return_True_When_Career_Be_added()
    {
        var course = new Course(new Category("teste"), "teste", "teste");
        course.AddCareer(Guid.NewGuid());
        Assert.True(course.CareerId is not null);
    }
    [Fact]
    public void Should_Return_False_When_Career_IsNotAdded()
    {
        var course = new Course(new Category("teste"), "teste", "teste");
        Assert.False(course.CareerId is not null);
    }
}