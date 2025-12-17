namespace MicroMagia.Domain.BackOffice.Exceptions;

public class UserException: ApplicationException
{
    public UserException(string menssage = DefaultMenssage): base(menssage)
    {
          
    }
    const string DefaultMenssage = "Error in User";
}