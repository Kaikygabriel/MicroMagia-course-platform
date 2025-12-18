using MicroMagia.Domain.BackOffice.Exceptions;
using MicroMagia.Domain.BackOffice.ObjectValue;

namespace MicroMagia.Test.Domain.ObjectValue;

public class EmailTest
{
    private const string? AdressEmail_Null = null;
    [Fact]
    public void Should_Return_Exception_If_AddressInEmail_Is_Null()
    {
        Assert.Throws<EmailException>(()
            => new Email(AdressEmail_Null));
    }
    private const string AdressEmail_Invalid = "tes";
    [Fact]
    public void Should_Return_Exception_If_AddressInEmail_LenghtSmall3()
    {
        Assert.Throws<EmailException>(()
            => new Email(AdressEmail_Invalid));
    }
    private const string AdressEmail_Valid = "teste@gmail.com";
    [Fact]
    public void Should_Return_NotNull_If_AddressInEmail_Is_Valid()
    {
        var email = new Email(AdressEmail_Valid);
        Assert.NotNull(email);
    }
   
}