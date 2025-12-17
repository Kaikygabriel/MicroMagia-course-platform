namespace MicroMagia.Domain.BackOffice.Exceptions;

public class StudentException: ApplicationException
{
     public StudentException(string menssage = DefaultMenssage): base(menssage)
     {
          
     }
     const string DefaultMenssage = "Error in Student";
}