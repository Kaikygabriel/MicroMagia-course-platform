using System.Security.Claims;

namespace MicroMagia.Application.Services.Abstractions;

public interface ITokenService
{
    string GenerateAccessToken(IEnumerable<Claim>claims);
    bool UserIsAuthor(string token);
}