using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using MicroMagia.Application.Services.Abstractions;
using MicroMagia.Domain.BackOffice.Interfaces;

namespace MicroMagia.Application.UseCases.Author.Command;

public class HandlerBaseAuthor :  HandlerBase
{
    protected readonly ITokenService _tokenService;
    public HandlerBaseAuthor(IUnitOfWork ofWork, ITokenService tokenService) : base(ofWork)
    {
        _tokenService = tokenService;
    }

    protected string GenerateTokenOfAuthor(Domain.BackOffice.Entities.Author entity)
    {
        var claims = GetClaimsOfAuthor(entity);
        var token = _tokenService.GenerateAccessToken(claims);
        return token;
    }
    
    protected IEnumerable<Claim> GetClaimsOfAuthor(Domain.BackOffice.Entities.Author entity)
        => new List<Claim>()
        {
            new Claim(ClaimTypes.Email, entity.User.Email.Address),
            new Claim(ClaimTypes.Name, entity.Name),
            new Claim(ClaimTypes.Role, "Author"),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N"))
        };
}