using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Domain.ObjectValue;

public class CategoryTest
{
    private const string? NameNull = null;
    [Fact]
    public void Should_Return_Exception_If_NameIsNull()
    {
        Assert.Throws<Exception>(() =>
        {
            new Category(NameNull);
        });
    }

    private const string Name_Invalid = "a";
    [Fact]
    public void Should_Return_Exception_If_NameIsSmall()
    {
        Assert.Throws<Exception>(() =>
        {
            new Category(Name_Invalid);
        });
    }

    private const string Name_Valid = "teste@gmail.com";
    [Fact]
    public void Should_Return_NotNull_If_NameOk()
    {
        var category = new Category(Name_Valid);
        Assert.NotNull(category);
    }
    [Fact]
    public void Should_Insert_Course_InListCourse()
    {
        var category = new Category(Name_Valid);
        category.AddCourse(new Course(category,"title","teste"));
        var existing = category.Courses.Any();
        Assert.True(existing);
    }
}