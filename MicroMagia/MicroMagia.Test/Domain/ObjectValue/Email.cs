namespace MicroMagia.Test.Domain.ObjectValue;

public class Email
{
    private const string? AdressEmail_Null = null;
    [Fact]
    public void Should_Return_Exception_If_AddressInEmail_Is_Null()
    {
        Assert.Fail();
    }
    private const string AdressEmail_Invalid = "tes";
    [Fact]
    public void Should_Return_Exception_If_AddressInEmail_LenghtSmall3()
    {
        Assert.Fail();
    }
    private const string AdressEmail_Valid = "teste@gmail.com";
    [Fact]
    public void Should_Return_NotNull_If_AddressInEmail_Is_Valid()
    {
        Assert.Fail();
    }
   
}