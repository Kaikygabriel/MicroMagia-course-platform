using MicroMagia.Domain.BackOffice.Entities;
using MicroMagia.Domain.BackOffice.Exceptions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Domain.Entity;

public class AuthorTest
{
    private readonly User UserValid = new(new Email("teste@gmail.com"), "skaldjflajdk");
     
    private const string? NameNull = null; 
    [Fact]
    public void Should_Return_Exception_If_NameIsNull()
    {
        Assert.Throws<Exception>(()
            => new Author(NameNull,UserValid));
    }
     
    private const string NameSmall = "te";
    [Fact]
    public void Should_Return_Exception_If_NameSmall()
    {
        Assert.Throws<Exception>(()
            => new Author(NameSmall,UserValid));
    }
     
    private const string NameValid= "teste";
    [Fact]
    public void Should_Return_NotNull_If_NameValid()
    {
        var author = new Author(NameValid, UserValid);
        Assert.NotNull(author);
    }

    [Fact]
    public void Should_Return_True_Author_Is_Premium()
    {
        var author = new Author(NameValid, UserValid);
        Assert.True(author.IsPremium);
    }
}