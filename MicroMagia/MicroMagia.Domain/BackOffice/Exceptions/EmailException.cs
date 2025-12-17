
namespace MicroMagia.Domain.BackOffice.Exceptions;

public class EmailException: ApplicationException
{
    public EmailException(string menssage = DefaultMenssage): base(menssage)
    {
          
    }
    const string DefaultMenssage = "Error in email";
}