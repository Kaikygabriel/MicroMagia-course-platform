namespace MicroMagia.Application.Services;

public static class ServiceCheckPassword
{
    public static bool VerifyPassword(string hashPassword, string password)
        => BCrypt.Net.BCrypt.Verify(password, hashPassword);
}