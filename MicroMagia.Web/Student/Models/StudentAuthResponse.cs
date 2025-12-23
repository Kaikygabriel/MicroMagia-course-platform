namespace MicroMagia.Web.Student.Models;

public class StudentAuthResponse
{
    public StudentAuthResponse(string token, string email)
    {
        Token = token;
        Email = email;
    }

    public string Token { get; set; }
    public string Email { get; set; }
}