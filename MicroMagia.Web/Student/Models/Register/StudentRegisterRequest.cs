namespace MicroMagia.Web.Student.Models;

public class StudentRegisterRequest
{
    public string Name { get; set; }
    public UserRegister userDto { get; set; }
}