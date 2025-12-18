using MicroMagia.Domain.BackOffice.Entities;

namespace MicroMagia.Test.Domain.Entity;

public class CareerTest
{
    private const string TitleNull = null ;
    [Fact]
    public void Should_Return_Exception_if_titleNull()
    {
        Assert.Throws<Exception>(() => new Career(TitleNull));
    }
    private const string TitleSmall = "at" ;
    [Fact]
    public void Should_Return_Exception_if_titleSmall()
    {
        Assert.Throws<Exception>(() => new Career(TitleSmall));
    }
    
    private const string TitleValid = "testet" ;
    [Fact]
    public void Should_Return_NotNull_if_titleOk()
    {
        var career = new Career(TitleValid);
        Assert.NotNull(TitleValid);
    }
}