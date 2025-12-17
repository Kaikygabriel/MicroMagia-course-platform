using MicroMagia.Domain.BackOffice.Exceptions;

namespace MicroMagia.Domain.BackOffice.ObjectValue;

public class Email
{
    protected Email()
    {
        
    }
    public Email(string address)
    {
        if (!IsValidAddress(address))
            throw new EmailException("Address is invalid ");
        Address = address;
    }

    public string Address { get; set; }

    private bool IsValidAddress(string address)
        => string.IsNullOrEmpty(address) || address.Contains('@') ;
}